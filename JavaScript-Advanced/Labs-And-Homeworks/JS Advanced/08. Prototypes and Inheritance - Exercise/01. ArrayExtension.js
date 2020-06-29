(function solve() {
    Array.prototype.last = function() {
        return this[this.length - 1];
    };

    Array.prototype.skip = function(n) {
        validateInputData(n);
        let newArray = [];

        for (let i = n; i < this.length; i++) {
            newArray.push(this[i]);
        }

        return newArray;
    };

    Array.prototype.take = function(n) {
        validateInputData(n);
        let newArray = [];

        for (let i = 0; i < n; i++) {
            newArray.push(this[i]);
        }

        return newArray;
    };

    Array.prototype.sum = function() {
        let sum = 0;

        for (let i = 0; i < this.length; i++) {
            sum += this[i];
        }

        return sum;
    };

    Array.prototype.average = function() {
        return this.sum() / this.length;
    };

    function validateInputData(index) {
        if (index < 0 || index >= this.length) {
            throw new Error('Index out of range!');
        }
    }
}());

let testArray = [1, 2, 3];
console.log(testArray.skip(1)[0]);
console.log(testArray.skip(1)[1]);
