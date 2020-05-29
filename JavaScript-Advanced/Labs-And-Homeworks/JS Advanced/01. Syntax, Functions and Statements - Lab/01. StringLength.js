function solve(firstInput, secondInput, thirdInput) {
    let sumLength = 0;
    let averageLength = 0;

    let firstInputLength = firstInput.length;
    let secondInputLength = secondInput.length;
    let thirdInputLength = thirdInput.length;

    sumLength = firstInputLength + secondInputLength + thirdInputLength;
    averageLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(averageLength);
}

solve('chocolate','ice cream', 'cake');