const library = require('./library')
const assert = require('chai').assert;

describe("Tests …", function () {
    // calcPriceOfBook function
    it('input should be string else throw error', () => {
        try {
            assert.throw(library.calcPriceOfBook(2, 2), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it('input should be int else throw error', () => {
        try {
            assert.throw(library.calcPriceOfBook('s', '2'), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it('input should not be empty else throw error', () => {
        try {
            assert.throw(library.calcPriceOfBook('s',), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it('input should not be empty else throw error', () => {
        try {
            assert.throw(library.calcPriceOfBook(), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it('input should not be empty else throw error', () => {
        try {
            assert.throw(library.calcPriceOfBook(undefined,2), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it ('the price should be 20', () => {
        assert.equal(library.calcPriceOfBook('s', 1982), `Price of s is 20.00`)
    })
    it ('should dicrease the price if the year is less then 1980', () => {
        assert.equal(library.calcPriceOfBook('s', 2), `Price of s is 10.00`)
    })

    // findBook function
    it ('should throw error if array is empty', () => {
        try {
            assert.throw(library.findBook([], 'sda'), TypeError)
        } catch (error) {
            assert.equal(error,'Error: No books currently available')
        }
    })
    it ('should find the book', ()=> {
        assert.equal(library.findBook(['sda'], 'sda'), 'We found the book you want.')
    }) 
    it ('should return message when the book is not found', ()=>{
        assert.equal(library.findBook(['asd'],'dsa'),'The book you are looking for is not here!')
    })

    // arrangeTheBooks function
    it ('param should be positive int else should throw an error', ()=>{
        try {
            assert.throw(library.arrangeTheBooks('2'), TypeError);
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it ('param should be positive int else should throw an error', ()=>{
        try {
            assert.throw(library.arrangeTheBooks(-2), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it ('param should be positive int else should throw an error', ()=>{
        try {
            assert.throw(library.arrangeTheBooks(), TypeError)
        } catch (error) {
            assert.equal(error,'Error: Invalid input')
        }
    })
    it ('should return "Great job, the books are arranged." if avalible space > count',()=>{
        assert.equal(library.arrangeTheBooks(40),'Great job, the books are arranged.')
    })
    it ('should return "Insufficient space, more shelves need to be purchased." if the space is not enough',()=>{
        assert.equal(library.arrangeTheBooks(41),'Insufficient space, more shelves need to be purchased.')
    })
});