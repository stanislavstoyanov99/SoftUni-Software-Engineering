function solve(inputArray) {
    const resultArray = [];
    let currNum = 1;

    for (const command of inputArray) {
        if (command === 'add') {
            resultArray.push(currNum++);
        }
        else if (command === 'remove') {
            currNum++;
            resultArray.pop();
        }
    }

    if (resultArray.length === 0) {
        console.log('Empty');
    }
    else {
        console.log(resultArray.join('\n'));
    }
}

solve(['add', 'add', 'add', 'add'])
solve(['add', 'add', 'remove', 'add', 'add'])
solve(['remove', 'remove', 'remove'])