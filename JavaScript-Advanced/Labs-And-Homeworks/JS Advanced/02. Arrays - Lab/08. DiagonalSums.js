// First solution with reduce
function findDiagonalSums(inputArray) {
    const diagonalSums = inputArray.reduce((acc, currValue, currRow) => {
        acc[0] += inputArray[currRow][currRow];
        acc[1] += inputArray[currRow][inputArray.length - currRow - 1];

        return acc;
    }, [0, 0]);

    console.log(diagonalSums.join(' '));
}

// Second solution with for loop
function findDiagonalSums2(inputArray) {
    let mainDiagonalSum = 0;
    let antiDiagonalSum = 0;
    let resultArray = [];

    for (let row = 0; row < inputArray.length; row++) {
        mainDiagonalSum += inputArray[row][row];
        antiDiagonalSum += inputArray[row][inputArray.length - row - 1];
    }

    resultArray.push(mainDiagonalSum);
    resultArray.push(antiDiagonalSum);

    console.log(resultArray.join(' '));
}

findDiagonalSums([[20, 40], [10, 60]]);
findDiagonalSums([[3, 5, 17], [-1, 7, 14], [1, -8, 89]]);
findDiagonalSums2([[20, 40], [10, 60]]);