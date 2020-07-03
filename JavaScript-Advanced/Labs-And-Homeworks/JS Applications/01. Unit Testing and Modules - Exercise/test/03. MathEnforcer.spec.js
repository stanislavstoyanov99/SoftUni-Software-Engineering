const expect = require('chai').expect;
const mathEnforcer = require('../03. MathEnforcer').mathEnforcer;

describe('Math Enforcer tests', function () {
    describe('addFive', function () {
        describe('Validations check', function () {
            it('should return undefined with a non-number argument', function () {
                const input = 'testInput';
                const result = mathEnforcer.addFive(input);
                expect(result).to.be.undefined;
            });
            
            it('should return undefined with an object argument', function () {
                const input = {test: 5};
                const result = mathEnforcer.addFive(input);
                expect(result).to.be.undefined;
            });    
        });

        describe('Happy path', function () {
            it('should return correct result with a positive number parameter', function () {
                const input = 5;
                const result = mathEnforcer.addFive(input);
                expect(result).to.equal(10, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative number parameter', function () {
                const input = -5;
                const result = mathEnforcer.addFive(input);
                expect(result).to.equal(0, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a positive floating-point number parameter', function () {
                const input = 5.20;
                const result = mathEnforcer.addFive(input);
                expect(result).to.equal(10.20, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative floating-point number parameter', function () {
                const input = -5.20;
                const result = mathEnforcer.addFive(input);
                expect(result).to.equal(-0.2, 'Incorrect result from addFive method!');
            });
        });
    });

    describe('subtractTen', function () {
        describe('Validations check', function () {
            it('should return undefined with a non-number argument', function () {
                const input = 'testInput';
                const result = mathEnforcer.subtractTen(input);
                expect(result).to.be.undefined;
            });
    
            it('should return undefined with an object argument', function () {
                const input = {test: 5};
                const result = mathEnforcer.subtractTen(input);
                expect(result).to.be.undefined;
            });
        });

        describe('Happy path', function () {
            it('should return correct result with a positive number parameter', function () {
                const input = 10;
                const result = mathEnforcer.subtractTen(input);
                expect(result).to.equal(0, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative number parameter', function () {
                const input = -5;
                const result = mathEnforcer.subtractTen(input);
                expect(result).to.equal(-15, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a positive floating-point number parameter', function () {
                const input = 10.20;
                const result = Number(mathEnforcer.subtractTen(input).toFixed(1));
                expect(result).to.equal(0.2, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative floating-point number parameter', function () {
                const input = -10.20;
                const result = mathEnforcer.subtractTen(input);
                expect(result).to.equal(-20.2, 'Incorrect result from addFive method!');
            });
        });
    });

    describe('sum', function () {
        describe('Validations check', function () {
            it('should return undefined if the first argument is non-number', function () {
                const arg1 = 'testInput';
                const arg2 = 2;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.be.undefined;
            });
    
            it('should return undefined if the second argument is non-number', function () {
                const arg1 = 2;
                const arg2 = 'testInput';
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.be.undefined;
            });

            it('should return undefined if the first argument is an object', function () {
                const arg1 = {test: 5};
                const arg2 = 2;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.be.undefined;
            });
    
            it('should return undefined if the second argument is an object', function () {
                const arg1 = 2;
                const arg2 = {test: 5};
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.be.undefined;
            });
        });

        describe('Happy path', function () {
            it('should return correct result with a positive number parameters', function () {
                const arg1 = 5;
                const arg2 = 5;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.equal(10, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative number parameters', function () {
                const arg1 = -5;
                const arg2 = 5;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.equal(0, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a positive floating-point number parameters', function () {
                const arg1 = 5.2;
                const arg2 = 5.2;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.equal(10.4, 'Incorrect result from addFive method!');
            });
    
            it('should return correct result with a negative floating-point number parameters', function () {
                const arg1 = -5.2;
                const arg2 = -5.2;
                const result = mathEnforcer.sum(arg1, arg2);
                expect(result).to.equal(-10.4, 'Incorrect result from addFive method!');
            });
        })
    });
});