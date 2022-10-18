const rentCar = require('./rentCar');
const assert = require('chai').assert;

describe('test', () => {
    it('should throw error', () => {
        try {
            assert.throw(rentCar.searchCar(2, '2'), TypeError);
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!')
        }
    })
    it('should throw error', () => {
        try {
            assert.throw(rentCar.searchCar([2], 2), TypeError);
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!')
        }
    })
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.searchCar(['audi'], 'bmw'), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: There are no such models in the catalog!');
        }
    })
    it('should return message', () => {
        assert.equal(rentCar.searchCar(['audi', 'vw', 'audi'], 'audi'), `There is 2 car of model audi in the catalog!`)
    })
    ////////////////////////////////////////
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.calculatePriceOfCar(2, 2), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.calculatePriceOfCar('Audi', 2.2), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.calculatePriceOfCar('Audi', '2'), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should return message', () => {
        assert.equal(rentCar.calculatePriceOfCar('Mercedes', 2), 'You choose Mercedes and it will cost $100!');
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.calculatePriceOfCar('ss', 2), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: No such model in the catalog!');
        }
    });
    ///////////////////////////////////////////
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget(2.2, 2, 3), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget(2, 2.2, 3), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget(2, 2, 3.1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget('2', 2, 3), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget(2, '2', 3), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should throw Error', () => {
        try {
            assert.throw(rentCar.checkBudget(2, 2, '3'), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid input!');
        }
    });
    it('should return message', () => {
        assert.equal(rentCar.checkBudget(1, 2, 3), `You rent a car!`)
    });
    it('should return message', () => {
        assert.equal(rentCar.checkBudget(2, 2, 3), 'You need a bigger budget!')
    });
    it('should return message', () => {
        assert.equal(rentCar.checkBudget(2, 2, 4), 'You need a bigger budget!')
    });
});