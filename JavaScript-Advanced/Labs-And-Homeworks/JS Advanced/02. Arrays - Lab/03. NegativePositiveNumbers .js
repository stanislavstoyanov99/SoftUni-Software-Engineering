function reorderNumbers(inputArray) {
    const resultArray = [];

    for (let i = 0; i < inputArray.length; i++) {
        const currNumber = Number(inputArray[i]);

        currNumber >= 0 ? resultArray.push(currNumber) : resultArray.unshift(currNumber);
    }

    console.log(resultArray.join('\n'));
}

reorderNumbers([7, -2, 8, 9]);
reorderNumbers([3, -2, 0, -1]);