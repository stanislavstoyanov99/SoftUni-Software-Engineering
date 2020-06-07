function printArray(inputArray) {
    const delimeter = inputArray.pop();
    const resultArray = inputArray.join(delimeter);

    console.log(resultArray);
}

printArray(['One', 'Two', 'Three', 'Four', 'Five', '-']);
printArray(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);