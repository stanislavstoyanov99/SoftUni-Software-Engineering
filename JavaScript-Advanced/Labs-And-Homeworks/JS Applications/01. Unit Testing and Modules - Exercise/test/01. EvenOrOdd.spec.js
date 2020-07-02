const expect = require('chai').expect;
const isOddOrEven = require('../01. EvenOrOdd').isOddOrEven;

describe('Is odd or even tests', function () {
    it('should return undefined with a number argument', function () {
        const input = 5;
        const result = isOddOrEven(input);
        expect(result).to.be.undefined;
    });

    it('should return undefined with an object argument', function () {
        const input = {number: 5};
        const result = isOddOrEven(input);
        expect(result).to.be.undefined;
    });

    it('should return even when passed string has even length', function () {
        const input = 'Five'
        const result = isOddOrEven(input);
        expect(result).to.be.eq('even');
    });

    it('should return odd when passed string has odd length', function () {
        const input = 'Car'
        const result = isOddOrEven(input);
        expect(result).to.be.eq('odd');
    });

    it('should return correct values with multiple consecutive checks', function () {
        const firstInput = 'sky';
        const firstResult = isOddOrEven(firstInput);

        const secondInput = 'take';
        const secondResult = isOddOrEven(secondInput);

        const thirdInput = 'unity';
        const thirdResult = isOddOrEven(thirdInput);

        expect(firstResult).to.be.eq('odd');
        expect(secondResult).to.be.eq('even');
        expect(thirdResult).to.be.eq('odd');
    });
});