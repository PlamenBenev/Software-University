const assert = require('chai').assert;
const companyAdministration = require('./companyAdministration');

describe('tests', () => {
    it('should', () => {
        try {
            assert.throw(companyAdministration.hiringEmployee('2', '2', 3), TypeError);
        } catch (error) {
            assert.equal(error, `Error: We are not looking for workers for this position.`);
        }
    });
    it('should', () => {
        assert.equal(companyAdministration.hiringEmployee('2', 'Programmer', 3), `2 was successfully hired for the position Programmer.`);
    });
    it('should', () => {
        assert.equal(companyAdministration.hiringEmployee('2', 'Programmer', 2), `2 is not approved for this position.`);
    });
    it('should', () => {
        try {
            assert.throw(companyAdministration.calculateSalary('2'), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid hours`);
        }
    });
    it('should', () => {
        try {
            assert.throw(companyAdministration.calculateSalary(-1), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid hours`);
        }
    });
    it('should', () => {
        assert.equal(companyAdministration.calculateSalary(1), 15);
    });
    it('should', () => {
        assert.equal(companyAdministration.calculateSalary(161), 3415);
    });
    /////////////////////////////////
    it('should', () => {
        try {
            assert.throw(companyAdministration.firedEmployee(-1, 1), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid input`);
        }
    });
    it('should', () => {
        try {
            assert.throw(companyAdministration.firedEmployee(['s'], -1), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid input`);
        }
    });
    it('should', () => {
        try {
            assert.throw(companyAdministration.firedEmployee(['s'], 1), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid input`);
        }
    });
    it('should', () => {
        try {
            assert.throw(companyAdministration.firedEmployee(['s'], 0.1), TypeError);
        } catch (error) {
            assert.equal(error, `Error: Invalid input`);
        }
    });
    it('should', () => {
        assert.equal(companyAdministration.firedEmployee(['s','d','f'],1), 's, f');
    });
});