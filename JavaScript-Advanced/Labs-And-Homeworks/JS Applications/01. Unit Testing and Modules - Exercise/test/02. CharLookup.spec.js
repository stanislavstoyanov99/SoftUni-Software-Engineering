const expect = require('chai').expect;
const lookupChar = require('../02. CharLookup').lookupChar;

describe('Char lookup tests', function () {
    it('should return undefined with a non-string first parameter', function () {
        const inputStr = 5;
        const result = lookupChar(inputStr, 0);
        expect(result).to.be.undefined;
    });

    it('should return undefined with a non-number second parameter', function () {
        const inputStr = 'Pesho'
        const result = lookupChar(inputStr, 'Kiro');
        expect(result).to.be.undefined;
    });

    it('should return undefined with a floating number as a second parameter', function () {
        const inputStr = 'Pesho'
        const result = lookupChar(inputStr, 3.56);
        expect(result).to.be.undefined;
    });

    it('should return message \'Incorrect index\' if the index is greater than inputStr length', function () {
        const inputStr = 'Pesho'
        const result = lookupChar(inputStr, 6);
        expect(result).to.be.eq('Incorrect index');
    });

    it('should return message \'Incorrect index\' if the index is equal to inputStr length', function () {
        const inputStr = 'Pesho'
        const result = lookupChar(inputStr, 5);
        expect(result).to.be.eq('Incorrect index');
    });

    it('should return message \'Incorrect index\' if the index is negative', function () {
        const inputStr = 'Pesho'
        const result = lookupChar(inputStr, -1);
        expect(result).to.be.eq('Incorrect index');
    });

    it('should return correct value with correct passed arguments', function () {
        const inputStr = 'Pesho'
        const firstResult = lookupChar(inputStr, 0);
        const secondResult = lookupChar(inputStr, 3);

        expect(firstResult).to.be.eq('P');
        expect(secondResult).to.be.eq('h');
    });
});