function Spy(obj, method) {
    const spy = {count: 0};
    let originalFunction = obj[method];

    obj[method] = function (...args) {
        this.count++;
        return originalFunction.apply(obj, args);
    }.bind(spy);

    return spy;
}

let obj = {
    method: () => "invoked"
}

let spy = Spy(obj, "method");

obj.method();
obj.method();
obj.method();

console.log(spy) // { count: 3 }