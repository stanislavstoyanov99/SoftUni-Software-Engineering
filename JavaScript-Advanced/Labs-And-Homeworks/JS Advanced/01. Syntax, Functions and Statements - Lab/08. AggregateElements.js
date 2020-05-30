function solve(numbers) {
    let sumOfNumbers = 0;
    let sumOfInversedNumbers = 0;
    let concatenatedNumbers = [];

    for (let i = 0; i < numbers.length; i++) {
        sumOfNumbers += numbers[i];
        sumOfInversedNumbers += 1 / numbers[i];
        concatenatedNumbers += numbers[i];
    }

    console.log(sumOfNumbers);
    console.log(sumOfInversedNumbers);
    console.log(concatenatedNumbers);
}

solve([1, 2, 3]);