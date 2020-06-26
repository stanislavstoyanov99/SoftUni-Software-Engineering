(function () {
    String.prototype.ensureStart = function (str) {
        let currString = this.toString();

        if (currString.startsWith(str)) {
            return currString;
        }

        return str + currString;
    }

    String.prototype.ensureEnd = function (str) {
        let currString = this.toString();

        if (currString.endsWith(str)) {
            return currString;
        }

        return currString + str;
    }

    String.prototype.isEmpty = function () {
        return !!!this.toString();  // parse value to boolean(!!) and return the opposite with another !
    }

    String.prototype.truncate = function (n) {
        const currString = this.toString();
        const ellipsis = '.'.repeat(3);

        if (n < 3) {
            return ellipsis;
        }

        if (currString.length <= n) {
            return currString;
        } else {
            let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(' ');

            if (lastIndex !== -1) {
                return this.toString().substring(0, lastIndex) + ellipsis;
            } else {
                return this.toString().substring(0, n - 3) + ellipsis;
            }
        }
    }

    String.format = function (string, ...params) {
        let arguments = [...params];
        
        return string.replace(/{(\d+)}/g,
            (match, number) => arguments[number] ? arguments[number] : match);
    }
})();

let str = 'my string';
str = str.ensureStart('my');
console.log(str);

str = str.ensureStart('hello ');
console.log(str);

str = str.truncate(16);
console.log(str);

str = str.truncate(14);
console.log(str);

str = str.truncate(8);
console.log(str);

str = str.truncate(4);
console.log(str);

str = str.truncate(2);
console.log(str);

str = String.format('The {0} {1} fox', 'quick', 'brown');
console.log(str);

str = String.format('jumps {0} {1}', 'dog');
console.log(str);
