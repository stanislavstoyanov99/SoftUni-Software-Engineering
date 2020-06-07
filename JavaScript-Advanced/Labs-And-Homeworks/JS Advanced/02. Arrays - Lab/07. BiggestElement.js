function findBiggestNumber(inputArray) {
    const flattenedMatrix = inputArray.flat();
    const biggestNumber = flattenedMatrix.reduce((acc, curr) => Math.max(acc, curr));

    return biggestNumber;
}

console.log(findBiggestNumber([[20, 50, 10], [8, 33, 145]]));
console.log(findBiggestNumber([[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]]));
