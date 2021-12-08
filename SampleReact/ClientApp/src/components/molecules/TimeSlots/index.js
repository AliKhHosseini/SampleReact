// @flow
import React from 'react';
//relative address should be fixed 
import { getTimeSlots, confirmTimeSlot, returnTimeSlot } from "../../../services/TimeSlotsService"


class TimeSlots extends React.Component {
    constructor() {
    
        super()

        this.state = {
            updateState: true,
            bookingSlots: [],
            selectedSlots: [],
            bookedSlots: [],
        }


        getTimeSlots().then(
            responses => {
                this.setState({
                    bookingSlots: responses
                })
            });


    }

    HandleSelectionClick(object) {  
        this.setState({ updateState: true })
        if (object.bookingStatus === "unavailable" || object.bookingStatus === "booked") {
            // Do nothing as this slot cannot be booked
        }
        else if (object.bookingStatus === "selected") {
            if (object.slotId !== this.state.selectedSlots[0].slotId &&
                object.slotId !== this.state.selectedSlots[this.state.selectedSlots.length - 1].slotId) {
                alert("You can only deselect the first or last selected time slot!")
            }
            else {
                object.bookingStatus = "available"
                this.setState({ selectedSlots: this.state.selectedSlots.filter(slots => slots.slotId !== object.slotId) })
            }
        }
        else {
            if (this.state.selectedSlots.length === 0) {
                object.bookingStatus = "selected"
                this.setState({ selectedSlots: [object] })
            }
            else if (object.slotId !== this.state.selectedSlots[0].slotId - 1 &&
                object.slotId !== this.state.selectedSlots[this.state.selectedSlots.length - 1].slotId + 1) {
                alert("You must select an adjacent time slot to those already selected!")
            }
            else {
                object.bookingStatus = "selected"
                this.state.selectedSlots.push(object)
                this.state.selectedSlots.sort((a, b) => {
                    return a.slotId - b.slotId
                })
            }
        }
    }


 


    //Need to refactor to not send all slots
    HandleConfirmClick() {
        confirmTimeSlot(this.state.selectedSlots)
            .then(responses => {
                this.setState({
                    selectedSlots: [],
                    bookingSlots: responses.bookingSlots,
                    bookedSlots: responses.bookedSlots,

                })
            });
    }



    HandleReturnSlotsClick(slotArray) {
        returnTimeSlot(slotArray)
            .then(responses => {
                this.setState({
                    selectedSlots: [],
                    bookingSlots: responses.bookingSlots,
                    bookedSlots:  responses.bookedSlots,

                })
            });
    }


  




    render() {
        return (
            <React.Fragment>
                {this.state.selectedSlots.length > 0 &&
                    <div className={"selectionWrapper"}>
                        <h2>{"Selected Booking Time"}</h2>
                        <div>
                            <div>{`Start Time: ${this.state.selectedSlots[0].startTime} - End Time: ${this.state.selectedSlots[this.state.selectedSlots.length - 1].endTime} `}
                                <button onClick={() => this.HandleConfirmClick()}>{"Confirm Booking"}</button>
                            </div>
                        </div>
                    </div>
                }
                {this.state.bookedSlots.length > 0 &&   
                    <div className={"bookedSlotsWrapper"}>
                        <h2>{"Booked Times"}</h2>
                        {this.state.bookedSlots.map(slotArray => {
                            return (
                                <div>
                                    <div>
                                        {`Start Time: ${slotArray[0].startTime} - End Time: ${slotArray[slotArray.length - 1].endTime} `}
                                        <button onClick={() => this.HandleReturnSlotsClick(slotArray)}>{"Return Booking"}</button>
                                    </div>
                                </div>
                            )
                        })}
                    </div>
                }
                <div className={"bookingSlotsWrapper"}>
                    {this.state.bookingSlots.map((slot) => {
                        return <div className={"bookingSlot " + slot.bookingStatus} onClick={() => this.HandleSelectionClick(slot)}>
                            <div>{`${slot.startTime} - ${slot.endTime}`}</div>
                        </div>
                    })}
                </div>

            </React.Fragment>
        )
    }
}

export default TimeSlots