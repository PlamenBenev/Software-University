const assert = require('chai').assert;
const flowerShop = require('./flowerShop');

describe('tests',()=>{
    it ('should throw invalid input for first argument',()=>{
        try {
            assert.throw(flowerShop.calcPriceOfFlowers(2,2,2),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should throw invalid input for second argument',()=>{
        try {
            assert.throw(flowerShop.calcPriceOfFlowers('2',2.2,2),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should throw invalid input for third argument',()=>{
        try {
            assert.throw(flowerShop.calcPriceOfFlowers('2',2,2.2),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should be correct output',()=>{
        assert.equal(flowerShop.calcPriceOfFlowers('2',2,2),'You need $4.00 to buy 2!')
    })
    ///////////////
    it ('should be the proper message if availible',()=>{
        assert.equal(flowerShop.checkFlowersAvailable('2',['2']),'The 2 are available!')
    })
    it ('should be the proper message if not availible',()=>{
        assert.equal(flowerShop.checkFlowersAvailable('3',['2']),'The 3 are sold! You need to purchase more!')
    })
    ///////////////////////////
    it ('should throw invalid input for first argument',()=>{
        try {
            assert.throw(flowerShop.sellFlowers('2',2),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should throw invalid input for second argument',()=>{
        try {
            assert.throw(flowerShop.sellFlowers(['2'],2.2),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should throw invalid input for negative number in the second argument',()=>{
        try {
            assert.throw(flowerShop.sellFlowers(['2','3'],-1),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should throw invalid input if second argument > first argument length',()=>{
        try {
            assert.throw(flowerShop.sellFlowers(['2','3'],3),TypeError);         
        } catch (error) {
            assert.equal(error,'Error: Invalid input!')
        }
    })
    it ('should be correct output',()=>{
        assert.equal(flowerShop.sellFlowers(['2','3','4'],1),'2 / 4'); 
    })
})