function checkDistanceBetweenPoints(inputArray) {
    let x1 = +inputArray[0];
    let y1 = +inputArray[1];
    let x2 = +inputArray[2];
    let y2 = +inputArray[3];

    const cartesianX = 0;
    const cartesianY = 0;

    isValid(x1, y1, cartesianX, cartesianY);
    isValid(x2, y2, cartesianX, cartesianY);
    isValid(x1, y1, x2, y2);

    function isValid(x1, y1, x2, y2) {
        const distanceBetweenPoints = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));

        const isInteger = Number.isInteger(distanceBetweenPoints);

        if (isInteger) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        } else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
    }
}

checkDistanceBetweenPoints([3, 0, 0, 4]);
checkDistanceBetweenPoints([2, 1, 1, 1]);