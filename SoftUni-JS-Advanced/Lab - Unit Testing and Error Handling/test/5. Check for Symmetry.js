const sum = require('../SoftuniJS');

const assert = require('chai').assert;

describe('sum of array of numbers', function () {
    it ('should be array and its symmetric',function () {
        let arr = [1,2,1];

        let result = sum(arr);

        assert.equal(result,true);
    })
    it ('should return true if its symmetic', function () {
        let arr = ['s',2,'s'];

        let result = sum(arr);

        assert.equal(result,true);
    })
    it ('should return true if array is empty',function () {
        let arr = [];

        let result = sum(arr);

        assert.equal(result,true);
    })
    it ('should return false if its not symmetric',function () {
        let arr = [1,2,2];

        let result = sum(arr);

        assert.equal(result,false);
    })
    it ('should return false if its not array',function () {
        let arr = 'gg'

        let result = sum(arr);

        assert.equal(result,false);
    })
});