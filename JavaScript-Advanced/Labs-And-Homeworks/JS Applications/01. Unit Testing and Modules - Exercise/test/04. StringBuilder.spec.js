const expect = require('chai').expect;
const StringBuilder = require('../04. StringBuilder');

describe('String Builder tests', function () {
    const inputStr = 'TestInput';

    describe('Instantiation and structure', function () {
        it('works with valid passed parameters', function () {
            expect(() => new StringBuilder(inputStr)).to.not.throw();
        });

        it('works with no passed parameters', function () {
            expect(() => new StringBuilder()).to.not.throw();
        });

        it('should throw exception when invalid parameter is passed to constructor', function () {
            expect(() => new StringBuilder(5)).to.throw();
        });
    });

    describe('Tests for constructor with no parameter', function () {
        let stringBuilder = null;

        beforeEach(function () {
            stringBuilder = new StringBuilder();
        });

        it('should have all properties', function () {
            expect(stringBuilder.hasOwnProperty('_stringArray')).to.be.true;
        });

        it('should have functions attached to the prototype', function () {
            expect(Object.getPrototypeOf(stringBuilder).hasOwnProperty('append')).to.be.true;
            expect(Object.getPrototypeOf(stringBuilder).hasOwnProperty('prepend')).to.be.true;
            expect(Object.getPrototypeOf(stringBuilder).hasOwnProperty('insertAt')).to.be.true;
            expect(Object.getPrototypeOf(stringBuilder).hasOwnProperty('remove')).to.be.true;
            expect(Object.getPrototypeOf(stringBuilder).hasOwnProperty('toString')).to.be.true;
        });

        it('should initialize _stringArray to an empty array', function () {
            expect(stringBuilder._stringArray instanceof Array).to.be.true;
            expect(stringBuilder._stringArray.length).to.equal(0);
        });
    });

    describe('Tests for constructor with parameter', function () {
        let stringBuilder = null;

        beforeEach(function () {
            stringBuilder = new StringBuilder(inputStr);
        });

        it('should initialize _stringArray correctly', function () {
            expect(stringBuilder._stringArray instanceof Array).to.be.true;
            const actualArray = stringBuilder._stringArray;
            const expectedArray = Array.from(inputStr);

            compareArrays(actualArray, expectedArray);
        });

        it('should append correctly', function () {
            const stringToAppend = 'hello';
            stringBuilder.append(stringToAppend);

            const actualArray = stringBuilder._stringArray;
            const expectedArray = Array.from(inputStr + stringToAppend);

            compareArrays(actualArray, expectedArray);
        });

        it('should prepend correctly', function () {
            const stringToPrepend = 'hi';
            stringBuilder.prepend(stringToPrepend);

            const actualArray = stringBuilder._stringArray;
            const expectedArray = Array.from(stringToPrepend + inputStr);

            compareArrays(actualArray, expectedArray);
        });

        it('should insert correctly', function () {
            const strToInsert = 'sky';
            stringBuilder.insertAt(strToInsert, 3);

            const actualArray = stringBuilder._stringArray;
            const expectedArray = Array.from(inputStr);

            expectedArray.splice(3, 0, ...strToInsert);
            compareArrays(actualArray, expectedArray);
        });

        it('should remove correctly', function () {
            stringBuilder.remove(0, 4);

            const actualArray = stringBuilder._stringArray;
            const expectedArray = Array.from('Input');

            compareArrays(actualArray, expectedArray);
        });

        it('should stringify correctly', function () {
            expect(stringBuilder.toString()).to.equal(inputStr);
        });
    });

    describe('Tests for methods with invalid parameters', function () {
        let stringBuilder = null;

        beforeEach(function () {
            stringBuilder = new StringBuilder(inputStr);
        });

        it('should throw error when invalid parameter is passed to append method', function () {
            const strToAppend = ['Hello'];
            expect(() => stringBuilder.append(strToAppend)).to.throw();
        });

        it('should throw error when invalid parameter is passed to prepend method', function () {
            const strToPrepend = {str: 'Sad story'};
            expect(() => stringBuilder.prepend(strToPrepend)).to.throw();
        });

        it('should throw error when invalid parameter is passed to insertAt method', function () {
            const strToInsert = ['Happy story'];
            const startIndex = 5;

            expect(() => stringBuilder.insertAt(strToInsert, startIndex)).to.throw();
        });
    });

    function compareArrays(actual, expected) {
        expect(actual.length).to.equal(expected.length);

        for (let i = 0; i < actual.length; i++) {
            expect(actual[i]).to.equal(expected[i]);
        }
    }
});