const expect = require('chai').expect;
const createCalculator = require('../04. AddSubtract').createCalculator;

describe("Create calculator tests", function () {
    it('should return calculator instance', function () {
        const calculator = createCalculator();
        expect(calculator).to.exist;
    });

    it('should add number correctly', function () {
        const calculator = createCalculator();
        calculator.add(7);
        const result = calculator.get();
        expect(result).to.be.eq(7);
    });

    it('should add number as string correctly', function () {
        const calculator = createCalculator();
        calculator.add('7');
        const result = calculator.get();
        expect(result).to.be.eq(7);
    });

    it('should subtract number correctly', function () {
        const calculator = createCalculator();
        calculator.subtract(7);
        const result = calculator.get();
        expect(result).to.be.eq(-7);
    });

    it('should subtract number as string correctly', function () {
        const calculator = createCalculator();
        calculator.subtract('7');
        const result = calculator.get();
        expect(result).to.be.eq(-7);
    });

    it('should return current value', function () {
        const calculator = createCalculator();
        const result = calculator.get();
        expect(result).to.be.eq(0);
    });
});