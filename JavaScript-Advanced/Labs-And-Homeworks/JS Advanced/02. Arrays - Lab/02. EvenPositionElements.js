// First solution with for loop
function findEvenNumbers(inputArray) {
    const evenNumbers = [];

    for (let i = 0; i < inputArray.length; i++) {
        if (i % 2 == 0) {
            evenNumbers.push(inputArray[i]);
        }
    }

    return evenNumbers.join(' ');
}

// Second solution with filter
function findEvenNumbersWithMap(inputArray) {
    const evenNumbers = inputArray.filter((num, index) => index % 2 == 0);

    return evenNumbers.join(' ');
}

console.log(findEvenNumbers(['20', '30', '40']));
console.log(findEvenNumbers(['5', '10']));

console.log(findEvenNumbersWithMap(['20', '30', '40']));
console.log(findEvenNumbersWithMap(['5', '10']));