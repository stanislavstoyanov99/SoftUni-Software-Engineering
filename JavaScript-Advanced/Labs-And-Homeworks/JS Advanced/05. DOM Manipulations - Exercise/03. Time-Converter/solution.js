function attachEventsListeners() {
    const daysBtn = document.getElementById('daysBtn');
    const hoursBtn = document.getElementById('hoursBtn');
    const minutesBtn = document.getElementById('minutesBtn');
    const secondsBtn = document.getElementById('secondsBtn');

    const daysInput = document.querySelector('#days');
    const hoursInput = document.querySelector('#hours');
    const miutesInput = document.querySelector('#minutes');
    const secondsInput = document.querySelector('#seconds');

    daysBtn.addEventListener('click', () => {
        const daysValue = Number(daysInput.value);

        const hours = daysValue * 24; // 1 day = 24 hours
        hoursInput.value = hours;

        const minutes = daysValue * 1440; // 1 day = 1440 minutes
        miutesInput.value = minutes;

        const seconds = daysValue * 86400; // 1 day = 86400 seconds
        secondsInput.value = seconds;
    });

    hoursBtn.addEventListener('click', () => {
        const hoursValue = Number(hoursInput.value);

        const days = hoursValue / 24; // 24 hours = 1 day
        daysInput.value = days;

        const minutes = hoursValue * 60; // 1 hour = 60 minutes
        miutesInput.value = minutes;

        const seconds = hoursValue * 3600; // 1 hour = 3600 seconds
        secondsInput.value = seconds;
    });

    minutesBtn.addEventListener('click', () => {
        const minutesValue = Number(miutesInput.value);

        const days = minutesValue / 1440; // 1440 minutes = 1 day
        daysInput.value = days;

        const hours = minutesValue / 60; // 60 minutes = 1 hour
        hoursInput.value = hours;

        const seconds = minutesValue * 60; // 1 minute = 60 seconds
        secondsInput.value = seconds;
    });

    secondsBtn.addEventListener('click', () => {
        const secondsValue = Number(secondsInput.value);

        const days = secondsValue / 86400; // 86400 seconds = 1 day
        daysInput.value = days;

        const hours = secondsValue / 3600; // 3600 seconds = 1 hour
        hoursInput.value = hours;

        const minutes = secondsValue / 60; // 60 seconds = 1 minute
        miutesInput.value = minutes;
    });
}