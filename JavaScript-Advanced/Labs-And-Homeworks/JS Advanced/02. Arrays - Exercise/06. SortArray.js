function sortArray(inputArray) {
    inputArray.sort(compareArrays);

    function compareArrays(a, b) {
        return a.length - b.length || a.localeCompare(b);
    }

    console.log(inputArray.join('\n'));
}

// sortArray(['alpha', 'beta', 'gamma'])
// sortArray(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George'])
sortArray(['test', 'Deny', 'omen', 'Default'])