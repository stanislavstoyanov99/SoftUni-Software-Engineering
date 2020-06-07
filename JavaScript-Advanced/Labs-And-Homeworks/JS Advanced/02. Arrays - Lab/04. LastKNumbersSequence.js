// First solution with reduce
function generateSequence(n, k) {
    const resultArray = [1];

    for (let i = 1; i < n; i++) {
        const startIndex = Math.max(0, i - k);

        const currentElement = resultArray
            .slice(startIndex, startIndex + k)
            .reduce((previous, curr) => previous + curr, 0);

        resultArray.push(currentElement);
    }

    console.log(resultArray.join(' '));
}

// Second solution with nested for loops
function generateSequence2(n, k) {
    const resultArray = [1];

    for (let i = 1; i < n; i++) {
        const startIndex = Math.max(0, i - k);
        const currArray = resultArray.slice(startIndex, startIndex + k);

        let sumOfNumbers = 0;
        for (let j = 0; j < currArray.length; j++) {
            sumOfNumbers += Number(currArray[j]);
        }

        resultArray.push(sumOfNumbers);
    }

    console.log(resultArray.join(' '));
}

generateSequence(6, 3);
generateSequence2(6, 3);