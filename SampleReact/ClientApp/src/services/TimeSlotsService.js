


export async function getTimeSlots() {

    const response = await fetch('/api/Schedule/TimeSlots');
    return await response.json();
}

export async function confirmTimeSlot(timeSlot) {

    const response = await fetch('/api/Schedule/Confirm', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(timeSlot)
    })
    return await response.json();
}


export async function returnTimeSlot(timeSlots) {

    const response = await fetch('/api/Schedule/Return', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(timeSlots)
    })
    return await response.json();
}






 