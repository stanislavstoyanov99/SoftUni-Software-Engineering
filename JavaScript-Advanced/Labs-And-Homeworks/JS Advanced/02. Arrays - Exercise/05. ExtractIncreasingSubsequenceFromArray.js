function solve(inputArray) {
    let maxNum = Number(inputArray[0]);

    const resultArray = inputArray.reduce((acc, currItem) => {
        if (maxNum <= currItem) {
            maxNum = currItem;
            acc.push(maxNum);
        }

        return acc;
    }, []);

    console.log(resultArray.join('\n'));
}

solve([1, 3, 8, 4, 10, 12, 3, 2, 24])
solve([1, 2, 3, 4])
solve([20, 3, 2, 15, 6, 1])