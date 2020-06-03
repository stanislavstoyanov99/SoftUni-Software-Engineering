// footprint length is in meters
// student speed is in km/h
function solve(numberOfSteps, footprintLength, studentSpeed) {
    const distance = numberOfSteps * footprintLength;
    let time = Math.round(distance / studentSpeed * 3.6);
    time += Math.floor(distance / 500) * 60;

    const seconds = time % 60;
    time -= seconds;
    time /= 60;

    const minutes = time % 60;
    time -= minutes;
    time /= 60;
    const hours = time;

    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`);

    function pad(num) {
        return ('0' + num).slice(-2);
    }
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);