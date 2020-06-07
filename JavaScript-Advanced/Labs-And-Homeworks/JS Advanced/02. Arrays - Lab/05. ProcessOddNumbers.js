// First solution
function processOddNumbers(inputArray) {
    const resultArray = inputArray
        .filter((num, index) => index % 2 != 0)
        .map(num => num * 2)
        .reverse()
        .join(' ');

    console.log(resultArray);
}

// Second solution
function processOddNumbers2(inputArray) {
    const resultArray = inputArray.reduce((acc, currValue, currIndex) => {
        if (currIndex % 2 != 0) {
            const doubled = currValue * 2;
            acc.push(doubled);
        }
        
        return acc;
    }, []);

    console.log(resultArray.reverse().join(' '));
}

// processOddNumbers([10, 15, 20, 25]);
// processOddNumbers([3, 0, 10, 4, 7, 3]);

processOddNumbers2([10, 15, 20, 25]);
processOddNumbers2([3, 0, 10, 4, 7, 3]);