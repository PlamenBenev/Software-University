const assert = require('chai').assert;
const mathEnforcer = require('../SoftuniJS')


describe(`Math enforcer tests`, () => {
    it ('add five should return undifined when input is NaN', () => {
        assert.equal(mathEnforcer.addFive('5'),undefined);
    });
    it ('add five should return 5 minus the input when input is negative', () => {
        assert.equal(mathEnforcer.addFive(-4),1);
    });
    it ('add five should be close to input', () => {
        assert.closeTo(mathEnforcer.addFive(1.1),6.1,0.01);
    });

    it ('subtractTen should return undifined when input is NaN', () => {
        assert.equal(mathEnforcer.subtractTen('5'),undefined);
    });
    it ('subtractTen should return -10 minus the input when input is negative', () => {
        assert.equal(mathEnforcer.subtractTen(-11),-21);
    });
    it ('subtractTen should be close to input', () => {
        assert.closeTo(mathEnforcer.subtractTen(11.1),1.1,0.01);
    });

    it ('sum should return undifined when first input is NaN', () => {
        assert.equal(mathEnforcer.sum('5', 5),undefined);
    });
    it ('sum should return undifined when second input is NaN', () => {
        assert.equal(mathEnforcer.sum(5, '5'),undefined);
    });
    it ('sum should return correct when inputs are negative', () => {
        assert.equal(mathEnforcer.sum(-4,-4),-8);
    });
    it ('add five should be close to input', () => {
        assert.closeTo(mathEnforcer.sum(1.1,2.2),3.3,0.01);
    });
})