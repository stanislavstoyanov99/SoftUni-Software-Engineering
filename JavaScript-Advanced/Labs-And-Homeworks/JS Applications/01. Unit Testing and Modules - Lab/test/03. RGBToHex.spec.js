const expect = require('chai').expect;
const rgbToHexColor = require('../03. RGBToHex').rgbToHexColor;

describe("RgbToHexColor tests", function () {
    it('should return undefined if red is out of the range', function () {
        const belowRange = rgbToHexColor(-1, 255, 255);
        const aboveRange= rgbToHexColor(256, 0, 0);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return undefined if green is out of the range', function () {
        const belowRange = rgbToHexColor(255, -1, 255);
        const aboveRange= rgbToHexColor(0, 256, 0);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return undefined if blue is out of the range', function () {
        const belowRange = rgbToHexColor(255, 255, -1);
        const aboveRange= rgbToHexColor(0, 0, 256);

        expect(belowRange).to.be.undefined;
        expect(aboveRange).to.be.undefined;
    });

    it('should return undefined if red argument is not a number', function () {
        const result = rgbToHexColor('red', 255, 255);

        expect(result).to.be.undefined;
    });

    it('should return undefined if green argument is not a number', function () {
        const result = rgbToHexColor(255, 'green', 255);

        expect(result).to.be.undefined;
    });

    it('should return undefined if blue argument is not a number', function () {
        const result = rgbToHexColor(255, 255, 'blue');

        expect(result).to.be.undefined;
    });

    it('should convert rgb to hex', function () {
        const input = [255, 0, 0];
        const result = rgbToHexColor(...input);

        expect(result).to.be.eq('#FF0000');
    });
});