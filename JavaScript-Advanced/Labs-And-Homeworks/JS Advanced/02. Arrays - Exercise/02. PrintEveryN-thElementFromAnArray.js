function printElementsWithSteps(inputArray) {
    const step = Number(inputArray.pop());
    const resultArray = [];
    
    for (let i = 0; i < inputArray.length; i += step) {
        resultArray.push(inputArray[i]);
    }

    console.log(resultArray.join('\n'));
}

printElementsWithSteps(['5', '20', '31', '4', '20', '2'])
printElementsWithSteps(['dsa', 'asd', 'test', 'tset', '2'])
printElementsWithSteps(['1', '2', '3', '4', '5', '6'])