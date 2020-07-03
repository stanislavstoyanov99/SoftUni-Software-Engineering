const expect = require('chai').expect;
const PaymentPackage = require('../05. PaymentPackage');

describe('Payment Package tests', function () {
    const validName = 'My Package';
    const validValue = 120;

    describe('Instantiation and structure', function () {
        let instance = null;

        beforeEach(() => {
            instance = new PaymentPackage(validName, validValue);
        });

        it('works with valid parameters', function () {
            expect(() => new PaymentPackage(validName, validValue)).to.not.throw();
        });

        it('should get all properties correctly', function () {
            expect(instance.name).to.equal(validName);
            expect(instance.value).to.equal(validValue);
            expect(instance.VAT).to.equal(20);
            expect(instance.active).to.equal(true);
        });

        it('does not work with invalid name', function () {
            expect(() => new PaymentPackage('', validValue)).to.throw();
            expect(() => new PaymentPackage(undefined, validValue)).to.throw();
            expect(() => new PaymentPackage({}, validValue)).to.throw();
        });

        it('does not work with invalid value', function () {
            expect(() => new PaymentPackage(validName, '')).to.throw();
            expect(() => new PaymentPackage(validName, undefined)).to.throw();
            expect(() => new PaymentPackage(validName, {})).to.throw();
        });

        it('has all properties', function () {
            expect(instance).to.has.property('name');
            expect(instance).to.has.property('value');
            expect(instance).to.has.property('VAT');
            expect(instance).to.has.property('active');
        });
    });

    describe('Accessors', function () {
        let instance = null;

        beforeEach(() => {
            instance = new PaymentPackage(validName, validValue);
        });

        it('should accept and set valid name', function () {
           instance.name = 'New Package';
           expect(instance.name).to.equal('New Package');
        });

        it('throws exception when invalid name is passed', function () {
            expect(() => instance.name = '').to.throw();
            expect(() => instance.name = undefined).to.throw();
            expect(() => instance.name = {}).to.throw();
        });

        it('should accept and set valid value', function () {
            instance.value = 50;
            expect(instance.value).to.equal(50);
        });

        it('throws exception when invalid value is passed', function () {
            expect(() => instance.value = '').to.throw();
            expect(() => instance.value = undefined).to.throw();
            expect(() => instance.value = -5).to.throw();
        });

        it('should accept and set valid VAT', function () {
            instance.VAT = 15;
            expect(instance.VAT).to.equal(15);
        });

        it('throws exception when invalid VAT is passed', function () {
            expect(() => instance.VAT = '').to.throw();
            expect(() => instance.VAT = undefined).to.throw();
            expect(() => instance.VAT = -5).to.throw();
        });

        it('should accept and set valid active', function () {
            instance.active = true;
            expect(instance.active).to.be.true;

            instance.active = false;
            expect(instance.active).to.be.false;
        });

        it('throws exception when invalid active is passed', function () {
            expect(() => instance.active = '').to.throw();
            expect(() => instance.active = undefined).to.throw();
            expect(() => instance.active = -5).to.throw();
        });
    });

    describe('toString', function () {
        it('should return the correct output', function () {
            const instance = new PaymentPackage(validName, validValue);

            const expected = `Package: ${instance.name}` + (instance.active === false ? ' (inactive)' : '') + '\n' +
                `- Value (excl. VAT): ${instance.value}\n` +
                `- Value (VAT ${instance.VAT}%): ${instance.value * (1 + instance.VAT / 100)}`

            const actual = instance.toString();
            
            expect(actual).to.equal(expected);
        });
    });
});