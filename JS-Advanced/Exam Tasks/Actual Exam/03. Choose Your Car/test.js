const assert = require('chai').assert;
const chooseYourCar = require('./chooseYourCar');

describe('tests', () => {
    it('should', () => {
        try {
            assert.throw(chooseYourCar.choosingType('Sedan', 'c', 1899), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Year!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.choosingType('Sedan', 'c', 2222), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Year!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.choosingType('s', 'c', 2021), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: This type of car is not what you are looking for.');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.choosingType('s', 'c', 2022.5), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Year!');
        }
    });
    it('should', () => {
        assert.equal(chooseYourCar.choosingType('Sedan', 'c', 2021), 'This c Sedan meets the requirements, that you have.');
    });
    it('should', () => {
        assert.equal(chooseYourCar.choosingType('Sedan', 'c', 2021.5), 'This c Sedan meets the requirements, that you have.');
    });
    it('should', () => {
        assert.equal(chooseYourCar.choosingType('Sedan', 'c', 2001), 'This Sedan is too old for you, especially with that c color.');
    });
    /////////////////////////////////////////////////
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName('s', 1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName(['s'], '1'), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName(['s'], 0.1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName(['s'], -1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName(['s'], 1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.brandName([], ), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        assert.equal(chooseYourCar.brandName(['s', 'd', 'b'], 1), 's, b');
    });
    it('should', () => {
        assert.equal(chooseYourCar.brandName(['s'], 0), '');
    });
    it('should', () => {
        assert.equal(chooseYourCar.brandName(['s', 'd'], 0), 'd');
    });
    it('should', () => {
        assert.equal(typeof(chooseYourCar.brandName(['s', 'd'], 0)), 'string');
    });
    
    ////////////////////////////////////
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption('1', 1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption(1, '1'), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption(-1, 1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption(1, -1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption(1, 0), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        try {
            assert.throw(chooseYourCar.carFuelConsumption(0, 1), TypeError)
        } catch (error) {
            assert.equal(error, 'Error: Invalid Information!');
        }
    });
    it('should', () => {
        assert.equal(chooseYourCar.carFuelConsumption(100, 1), 'The car is efficient enough, it burns 1.00 liters/100 km.');
    });
    it('should', () => {
        assert.equal(chooseYourCar.carFuelConsumption(1, 1), 'The car burns too much fuel - 100.00 liters!');
    });
    it('should', () => {
        assert.equal(chooseYourCar.carFuelConsumption(100, 7), 'The car is efficient enough, it burns 7.00 liters/100 km.');
    });
    it('should', () => {
        assert.equal(chooseYourCar.carFuelConsumption(100, 6.5), 'The car is efficient enough, it burns 6.50 liters/100 km.');
    });
    it('should', () => {
        assert.equal(chooseYourCar.carFuelConsumption(100.5, 6), 'The car is efficient enough, it burns 5.97 liters/100 km.');
    });
});