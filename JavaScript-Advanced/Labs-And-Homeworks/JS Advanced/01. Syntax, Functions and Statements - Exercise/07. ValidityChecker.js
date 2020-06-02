function checkDistanceBetweenPoints(inputArray) {
    let x1 = +inputArray[0];
    let y1 = +inputArray[1];
    let x2 = +inputArray[2];
    let y2 = +inputArray[3];

    let cartesianX = 0;
    let cartesianY = 0;

    let distanceBetweenPoints = Math.sqrt(Math.pow(x2 - x1, 2) + Math.pow(y2 - y1, 2));
    let distanceBetweenCartesianFirstPoint = Math.sqrt(Math.pow(x1 - cartesianX, 2) + Math.pow(y1 - cartesianY, 2));
    let distanceBetweenCartesianSecondPoint = Math.sqrt(Math.pow(x2 - cartesianX, 2) + Math.pow(y2 - cartesianY, 2));

    let isValidDistanceBetweenPoints = Number.isInteger(distanceBetweenPoints);
    let isFirstPointValidWithCartesian = Number.isInteger(distanceBetweenCartesianFirstPoint);
    let isSecondPointValidWithCartesian = Number.isInteger(distanceBetweenCartesianSecondPoint);

    if (isFirstPointValidWithCartesian === true) {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }

    if (isSecondPointValidWithCartesian === true) {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }
    else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (isValidDistanceBetweenPoints === true) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
}

checkDistanceBetweenPoints([3, 0, 0, 4]);
checkDistanceBetweenPoints([2, 1, 1, 1]);