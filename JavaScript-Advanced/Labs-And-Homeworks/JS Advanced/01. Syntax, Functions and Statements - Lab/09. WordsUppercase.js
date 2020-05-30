function printUpperWords(input) {
    return input
        .split(/\.\s+|\.|,\s+|,|\/|!|\?|\s+|-|_|'|"/g)
        .filter(word => word)
        .join(', ')
        .toUpperCase();
}

console.log(printUpperWords('Hi, how are you?'));