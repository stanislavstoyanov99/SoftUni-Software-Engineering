function checkSpeedLimit(input) {
    let data = input
        .toString()
        .split(',');
    const speed = Number(data[0]);
    const area = String(data[1]);

    let speedLimit = 0;
    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    let resultMessage = "";

    if (speed > speedLimit) {
        const speedOverTheLimit = speed - speedLimit;

        if (speedOverTheLimit <= 20) {
            resultMessage = "speeding";
        }
        else if (speedOverTheLimit <= 40) {
            resultMessage = "excessive speeding";
        }
        else {
            resultMessage = "reckless driving";
        }
    }

    console.log(resultMessage);
}

checkSpeedLimit([40, 'city']);
checkSpeedLimit([21, 'residential']);
checkSpeedLimit([120, 'interstate']);
checkSpeedLimit([200, 'motorway']);