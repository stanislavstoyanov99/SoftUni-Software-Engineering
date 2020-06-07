function isMatrixMagical(matrix) {
    for (let row = 0; row < matrix.length; row++) {
        const rowSum = matrix[row].reduce((a, b) => a + b, 0);
        let colSum = 0;

        for (let col = 0; col < matrix.length; col++) {
            colSum += matrix[col][row];
        }

        colSum = 0;
        return rowSum === colSum ? true : false;
    }
}

// console.log(isMatrixMagical([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));
// console.log(isMatrixMagical([[11, 32, 45], [21, 0, 1], [21, 1, 1]]));
console.log(isMatrixMagical([[1, 0, 0], [0, 0, 1], [0, 1, 0]]));