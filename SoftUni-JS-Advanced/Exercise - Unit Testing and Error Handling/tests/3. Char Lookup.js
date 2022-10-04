const lookupChar = require('../SoftuniJS');

const assert = require('chai').assert;

describe('odd or even numbers', function () {
    it ('should return undifined when input is not a string', () => {
        assert.equal(lookupChar(2,3),undefined);
    })
    it ('should return undifined when input is not a int', () => {
        assert.equal(lookupChar('2','s'),undefined);
    })
    it ('should return undifined when input is empty', () => {
        assert.equal(lookupChar(),undefined);
    })
    it ('should return Incorrect index when string length is less the index', () => {
        assert.equal(lookupChar('s',2),'Incorrect index');
    })
    it ('should return Incorrect index when index is negative', () => {
        assert.equal(lookupChar('s',-2),'Incorrect index');
    })
    it ('should return the correct answer', () => {
        assert.equal(lookupChar('ss',1),'s');
    })
    it ('should return Incorrect index when index is float', () => {
        assert.equal(lookupChar('s',1.1),undefined);
    })
});