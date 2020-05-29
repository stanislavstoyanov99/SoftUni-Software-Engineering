// First solution
function solve(firstNumber, secondNumber, operator) {
    let result = 0;
    switch (operator) {
        case '+': 
            result = firstNumber + secondNumber;
            break;
        case '-':
            result = firstNumber - secondNumber;
            break;
        case '/':
            result = firstNumber / secondNumber;
            break;
        case '*':
            result = firstNumber * secondNumber;
            break;
        case '%':
            result = firstNumber % secondNumber;
            break;
        case '**':
            result = firstNumber ** secondNumber;   
            break; 
    }

    console.log(result);
}

solve(5, 6, '+');

// Second Solution
function secondSolve(firstNumber, secondNumber, operator) {
    const cases = {
        '+': (x, y) => x + y,
        '-': (x, y) => x - y,
        '/': (x, y) => x / y,
        '*': (x, y) => x * y,
        '%': (x, y) => x % y,
        '**': (x, y) => x ** y,
    };

    let result = cases[operator](firstNumber, secondNumber);
    console.log(result);
}

secondSolve(5, 6, '*');