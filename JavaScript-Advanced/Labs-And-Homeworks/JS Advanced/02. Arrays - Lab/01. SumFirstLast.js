function sumOfFirstAndLastElements(inputArray) {
    const firstNumber = Number(inputArray[0]);
    const lastNumber = Number(inputArray[inputArray.length - 1]);
    const sumOfNumbers = firstNumber + lastNumber;

    console.log(sumOfNumbers);
}

sumOfFirstAndLastElements(['20', '30', '40']);
sumOfFirstAndLastElements(['5', '10']);