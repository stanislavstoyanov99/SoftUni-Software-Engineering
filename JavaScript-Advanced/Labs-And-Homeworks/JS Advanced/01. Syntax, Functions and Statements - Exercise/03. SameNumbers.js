function solve(number) {
    let digit = number.toString()[0];
    let isTheSameDigit = true;
    let sumOfDigits = Number(digit);
    let numberAsString = number.toString();

    for (let i = 1; i < numberAsString.length; i++) {
        let currDigit = numberAsString[i];
        if (currDigit != digit) {
            isTheSameDigit = false;
        }

        sumOfDigits += Number(currDigit);
    }

    console.log(isTheSameDigit)
    console.log(sumOfDigits);
}

solve(2222222);