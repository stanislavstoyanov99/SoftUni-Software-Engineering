const expect = require('chai').expect;
const isSymmetric = require('../02. CheckForSymmetry').isSymmetric;

describe("Is symmetric tests", function () {
    it('should return false if arr argument is not an array', function () {
        const arg = 'testArray';
        const result = isSymmetric(arg);
        expect(result).to.be.false;
    });

    it('should return true if the array is symmetric', function () {
        const arg = [2, 2, 2, 2];
        const result = isSymmetric(arg);
        expect(result).to.be.true;
    });

    it('should return false if the array is not symmetric', function () {
        const arg = ['1', '2', '3'];
        const result = isSymmetric(arg);
        expect(result).to.be.false;
    });
});