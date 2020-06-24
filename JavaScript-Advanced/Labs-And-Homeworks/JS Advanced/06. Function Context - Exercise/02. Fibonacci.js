function getFibonator() {
    let previous = 1;
    let curr = 0;

    return fibonator;
    
    function fibonator() {
        let newNumber = previous + curr;
        curr = previous;
        previous = newNumber;

        return curr;
    }
}

let fib = getFibonator();

console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
