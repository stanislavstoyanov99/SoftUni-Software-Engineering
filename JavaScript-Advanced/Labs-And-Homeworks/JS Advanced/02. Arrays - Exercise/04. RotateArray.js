function rotateArray(inputArray) {
    const rotationsCount = Number(inputArray.pop()) % inputArray.length;

    for (let i = 0; i < rotationsCount; i++) {
        const lastElement = inputArray.pop();
        inputArray.unshift(lastElement);
    }

    console.log(inputArray.join(' '));
}

rotateArray(['1', '2', '3', '4', '2'])
rotateArray(['Banana', 'Orange', 'Coconut', 'Apple', '15'])