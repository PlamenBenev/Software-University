const sum = require('../SoftuniJS');

const assert = require('chai').assert;

describe('RGB to hex', function () {
    it('takes 3 args', function () {
        let result = sum( 1, 1);

        assert.equal(result,undefined);
    })
    it('takes numbers', function () {
        let result = sum('1',1, 1);

        assert.equal(result,undefined);
    })
    it('in range', function () {
        let result = sum(-1 ,1, 256);

        assert.equal(result,undefined);
    })
    it('returns string', function () {
        let result = sum(2 ,2, 2);

        assert.equal(result,'#020202');
    })
});