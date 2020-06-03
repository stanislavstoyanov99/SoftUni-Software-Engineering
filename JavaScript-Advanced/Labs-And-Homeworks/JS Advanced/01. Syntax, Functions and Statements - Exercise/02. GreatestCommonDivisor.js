function computeCommonDivisor(firstNumber, secondNumber) {
    let x = Math.abs(firstNumber);
    let y = Math.abs(secondNumber); // truty value

    while (y != 0) {
        let remainder = y;
        y = x % y;
        x = remainder;
    }

    return x;
}

console.log(computeCommonDivisor(15, 5));
console.log(computeCommonDivisor(2154, 458));