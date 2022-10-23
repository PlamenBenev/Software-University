function getFibonator() {
    let currNum = 1;
    let lastNum = 0;
    function multiplier() {
        let toReturn = currNum + lastNum;
        currNum = lastNum;
        lastNum = toReturn;
        return toReturn;
    }
    return multiplier;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13