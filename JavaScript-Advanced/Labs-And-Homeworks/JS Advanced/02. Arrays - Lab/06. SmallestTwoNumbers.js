function printTwoSmallestNumbers(inputArray) {
    inputArray.sort((a, b) => a - b);

    const resultArray = inputArray.slice(0, 2);

    console.log(resultArray.join(' '));
}

printTwoSmallestNumbers([30, 15, 50, 5]);
printTwoSmallestNumbers([3, 0, 10, 4, 7, 3]);
