function solve(input) {
    let inputType = typeof(input);

    if (inputType == 'number') {
        let radius = +input;
        let area = Math.PI * Math.pow(radius, 2);
        return area.toFixed(2);
    }
    else {
        return `We can not calculate the circle area, because we receive a ${inputType}.`;
    }
}

console.log(solve(5));
console.log(solve('name'));