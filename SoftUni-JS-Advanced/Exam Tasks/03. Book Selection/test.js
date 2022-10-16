const assert = require('chai').assert;
const bookSelection = require('./bookSelection');

describe('test', () => {
    // isGenreSuitable
    it('should return kids message', () => {
        assert.equal(bookSelection.isGenreSuitable("Thriller", 12),
            `Books with Thriller genre are not suitable for kids at 12 age`);
    })
    it('should return kids message', () => {
        assert.equal(bookSelection.isGenreSuitable("Horror", 12),
            `Books with Horror genre are not suitable for kids at 12 age`);
    })
    it('should return kids message', () => {
        assert.equal(bookSelection.isGenreSuitable("Horror", 13),
            `Those books are suitable`);
    })
    // isItAffordable
    it('should throw Invalid input', () => {
        try {
            assert.Throw(bookSelection.isItAffordable('s',2),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input');
        }
    });
    it('should throw Invalid input', () => {
        try {
            assert.Throw(bookSelection.isItAffordable(2,'2'),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input');
        }
    });
    it('should return not enough money message', () => {
        assert.equal(bookSelection.isItAffordable(3, 2),"You don't have enough money");
    })
    it('should return book bought message', () => {
        assert.equal(bookSelection.isItAffordable(2, 3),"Book bought. You have 1$ left");
    })
    // suitableTitles
    it('should throw Invalid input', () => {
        try {
            assert.Throw(bookSelection.suitableTitles(2,'2'),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input');
        }
    });
    it('should throw Invalid input', () => {
        try {
            assert.Throw(bookSelection.suitableTitles([2],2),TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input');
        }
    });
    it('should be correct', () => {
        let arr = [{ title: "The Da Vinci Code", genre: "Thriller" },
        { title: "asd", genre: "Thriller" }];
        let check = bookSelection.suitableTitles(arr,'Thriller');
      assert.equal(check.length,2);
    });
    it('should be correct', () => {
        let arr = [{ title: "The Da Vinci Code", genre: "Thriller" },
        { title: "asd", genre: "ss" }];
        let check = bookSelection.suitableTitles(arr,'Thriller');
      assert.equal(check,"The Da Vinci Code");
    });
})