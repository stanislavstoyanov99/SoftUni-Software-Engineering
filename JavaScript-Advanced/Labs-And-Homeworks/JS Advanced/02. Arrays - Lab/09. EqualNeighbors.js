function findEqualNeighbours(matrix) {
    const result = matrix.reduce((acc, currRow, rowIndex) => {
        const currCount = currRow.reduce((acc, currValue, currIndex) => {
            if (currValue === currRow[currIndex + 1]) {
                acc += 1;
            };

            if (currValue === (matrix[rowIndex + 1] || [])[currIndex]) {
                acc += 1;
            }

            return acc;
        }, 0);

        return currCount + acc;
    }, 0);

    return result;
}

console.log(
    findEqualNeighbours([['2', '3', '4', '7', '0'], ['4', '0', '5', '3', '4'], ['2', '3', '5', '4', '2'], ['9', '8', '7', '5', '4']]));

console.log(
    findEqualNeighbours([['test', 'yes', 'yo', 'ho'], ['well', 'done', 'yo', '6'], ['not', 'done', 'yet', '5']]));