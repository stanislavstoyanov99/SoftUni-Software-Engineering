function isMatrixMagical(matrix) {
    let isMagic = true;
    const firstRowSum = matrix[0].reduce((a, b) => a + b, 0);

    for (let row = 0; row < matrix.length; row++) {
        const rowSum = matrix[row].reduce((a, b) => a + b, 0);
        const colSum = matrix.map(x => x[row]).reduce((a, b) => a + b, 0);

        if (rowSum !== firstRowSum || colSum !== firstRowSum) {
            isMagic = false;
        }
    }

    return isMagic;
}

console.log(isMatrixMagical([[4, 5, 6], [6, 5, 4], [5, 5, 5]]));
console.log(isMatrixMagical([[11, 32, 45], [21, 0, 1], [21, 1, 1]]));
console.log(isMatrixMagical([[1, 0, 0], [0, 0, 1], [0, 1, 0]]));