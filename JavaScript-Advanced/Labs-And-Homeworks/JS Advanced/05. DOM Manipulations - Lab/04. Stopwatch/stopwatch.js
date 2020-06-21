function stopwatch() {
    const startBtn = document.getElementById('startBtn');
    const stopBtn = document.getElementById('stopBtn');
    const time = document.getElementById('time');

    let intervalId;
    let seconds = 0;
    let minutes = 0;

    function formatOutput(value) {
        let text = value.toString();
        if (value < 10) { text = '0' + text; }
        return text;
    }

    function formatResult(minutes, seconds) {
        time.textContent = `${formatOutput(minutes)}:${formatOutput(seconds)}`;
    }

    function start() {
        minutes = 0;
        seconds = 0;
        formatResult(minutes, seconds);
        
        startBtn.setAttribute('disabled', true);
        stopBtn.removeAttribute('disabled');

        intervalId = setInterval(function () {
            seconds++;
            if (seconds === 60) {
                seconds = 0;
                minutes++;
            }

            formatResult(minutes, seconds);
        }, 1000);
    }

    function stop() {
        stopBtn.setAttribute('disabled', true);
        startBtn.removeAttribute('disabled');
        clearInterval(intervalId);
    }

    startBtn.addEventListener('click', start);
    stopBtn.addEventListener('click', stop);
}