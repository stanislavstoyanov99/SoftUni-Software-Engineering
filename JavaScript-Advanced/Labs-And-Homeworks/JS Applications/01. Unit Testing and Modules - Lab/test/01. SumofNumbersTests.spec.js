const expect = require('chai').expect;
const sum = require('../01. SumOfNumbers').sum;

describe("sum", function () {
    it('should return NaN if array is a string', function () {
        const arg = 'testString';
        const result = sum(arg);
        expect(result).to.be.NaN;
    });
})