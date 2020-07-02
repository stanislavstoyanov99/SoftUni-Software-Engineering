const expect = require('chai').expect;
const sum = require('../01. SumOfNumbers').sum;

describe("Sum tests", function () {
    it('should return NaN if array is a string', function () {
        const arg = 'testString';
        const result = sum(arg);
        expect(result).to.be.NaN;
    });

    it('should return the sum of elements in the array', function () {
        const arg = [1, 2, 3];
        const result = sum(arg);
        expect(result).to.eq(6, 'the result should be 6');
    });

    it('should return the sum of string elements in the array', function () {
        const arg = ['1', '2', '3'];
        const result = sum(arg);
        expect(result).to.eq(6, 'the result should be 6');
    });
});