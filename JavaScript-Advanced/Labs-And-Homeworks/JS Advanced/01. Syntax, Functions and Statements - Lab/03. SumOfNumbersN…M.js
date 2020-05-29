function solve(firstNumberAsString, secondNumberAsString) {
    let firstNumber = +firstNumberAsString;
    let secondNumber = +secondNumberAsString;

    let result = 0;
    for (let i = firstNumber; i <= secondNumber; i++) {
        result += i;
    }

    return result;
}

console.log(solve('5', '5'));
console.log(solve('-1', '5'));