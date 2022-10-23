const carService = require('./03. Car Service_Resources');
const assert = require('chai').assert;

describe('tests', () => {
    // is it expensive
    it('should return "bit cheaper" message', () => {
        assert.equal(carService.isItExpensive('ss'),`The overall price will be a bit cheaper`);
    })
    it('should return "cost more" message', () => {
        assert.equal(carService.isItExpensive('Engine'),`The issue with the car is more severe and it will cost more money`);
    })
    it('should return "cost more" message', () => {
        assert.equal(carService.isItExpensive('Transmission'),`The issue with the car is more severe and it will cost more money`);
    })
    // discount
    it('should return "Invalid input" message if numberOfParts is invalid', () => {
        try {
            assert.throw(carService.discount('2',3),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it('should return "Invalid input" message if price is invalid', () => {
        try {
            assert.throw(carService.discount(2,'3'),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it ('the discount should be 15% if number of parts is higher then 2 and less then 7', ()=>{
        assert.equal(carService.discount(3,20),`Discount applied! You saved ${20 * 0.15}$`)
    });
    it ('the discount should be 30% if number of parts is higher then 7', ()=>{
        assert.equal(carService.discount(8,20),`Discount applied! You saved ${20 * 0.30}$`)
    });
    it ('should return "You cannot apply a discount"', ()=>{
        assert.equal(carService.discount(2,20),`You cannot apply a discount`)
    });
    // parts to buy
    it ('input0 must be array', ()=>{
        try {
            assert.throw(carService.partsToBuy([{}],'3'),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    });
    it ('input1 must be array', ()=>{
        try {
            assert.throw(carService.partsToBuy(3,[{}]),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    });
    it ('should return 0 if partCatalog is empty', () => {
        assert.equal(carService.partsToBuy([],[{}]),0)
    })
    it ('should return correct output', () => {
        assert.equal(carService.partsToBuy([{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }], ["blowoff valve", "injectors"]),145);
    })
})