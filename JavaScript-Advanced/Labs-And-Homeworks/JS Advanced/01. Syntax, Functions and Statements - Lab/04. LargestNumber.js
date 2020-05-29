// First Solution
function firstSolve() {
    let args = Array.from(arguments);
    let max = args[0];

    for (let i = 1; i < args.length; i++) {
        if (max < args[i]) {
            max = args[i];
        }
    }

    return `The largest number is ${max}.`;
}

// Second Solution
function secondSolve(firstNumber, secondNumber, thirdNumber) {
    let maxNumber = Math.max(firstNumber, secondNumber, thirdNumber);
    return `The largest number is ${maxNumber}.`;
}

console.log(firstSolve(1, 2, 3));
console.log(secondSolve(2, 5, 1));