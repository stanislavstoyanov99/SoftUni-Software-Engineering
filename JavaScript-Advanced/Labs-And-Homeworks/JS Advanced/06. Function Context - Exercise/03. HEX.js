class Hex {
    constructor(number) {
        this.number = number;
    }

    valueOf() {
        return this.number;
    }

    toString() {
        return '0x' + (this.number.toString(16)).toUpperCase();
    }

    plus(obj) {
        const isNumber = Number.isInteger(obj);

        if (isNumber) {
            this.number += obj;
            return new Hex(this.number);
        }

        const value = this.number + obj.number;
        return new Hex(value);
    }

    minus(obj) {
        const isNumber = Number.isInteger(obj);

        if (isNumber) {
            this.number -= obj;
            return new Hex(this.number);
        }

        const value = this.number - obj.number;
        return new Hex(value);
    }

    parse(input) {
        return parseInt(input, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
console.log(FF.valueOf() + 1 === 256);

let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');