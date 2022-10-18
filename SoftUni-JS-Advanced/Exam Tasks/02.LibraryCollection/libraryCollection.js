class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length == this.capacity) {
            throw new Error("Not enough space in the collection.");
        }
        this.books.push({
            bookName: bookName,
            bookAuthor: bookAuthor,
            payed: false,
        });
        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        let theBook = this.books.find(x => x.bookName == bookName);
        if (theBook == undefined) {
            throw new Error(`${bookName} is not in the collection.`);
        }
        if (theBook.payed == true) {
            throw new Error(`${bookName} has already been paid.`);
        }
        theBook.payed = true;
        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let theBook = this.books.find(x => x.bookName == bookName);
        if (theBook == undefined) {
            throw new Error("The book, you're looking for, is not found.");
        }
        if (!theBook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        theBook.payed = true;
        let index = this.books.indexOf(theBook);
        this.books.splice(index, 1);
        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let result;
        let arr = [];
        let isItPaid = 'Not Paid';

        if (bookAuthor == undefined) {
            result = `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;
            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            this.books.forEach(x => {
                if (x.payed == true) { isItPaid = 'Has Paid' }
                else { isItPaid = 'Not Paid'};
                arr.push(`${x.bookName} == ${x.bookAuthor} - ${isItPaid}.`);
            });
            result += arr.join('\n');
        } else {
            this.books.forEach(x => {
                if (x.payed == true) { isItPaid = 'Has Paid' }
                else { isItPaid = 'Not Paid'};
                if (x.bookAuthor == bookAuthor){
                    arr.push(`${x.bookName} == ${x.bookAuthor} - ${isItPaid}.`);
                }
            });
            result = arr.join('\n');
        }
        if (arr.length == 0){
            throw new Error(`${bookAuthor} is not in the collection.`);
        }
        return result;

    }
}