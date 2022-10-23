class Stringer {
  constructor(innerString, innerLength) {
    this.innerString = innerString;
    this.innerLength = innerLength;
  }

  toString() {
     let result = this.innerString.slice(0,this.innerLength);
     if (result.length < this.innerString.length){
      result += '...';
     }
    
    return result;
  }
  increase(input) {
    this.innerLength += input;
    return this.innerLength;
  }
  decrease(input) {
    if (this.innerLength - input < 0){
      this.innerLength = 0;
    } else {
      this.innerLength -= input;
    }
    return this.innerLength;
  }
}
let test = new Stringer("Test", 5);
console.log(test.toString()); // Test
test.decrease(3);
console.log(test.toString()); // Te...
test.decrease(5);
console.log(test.toString()); // ...
test.increase(4);
console.log(test.toString()); // Test