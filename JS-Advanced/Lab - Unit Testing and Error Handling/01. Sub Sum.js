function solve(arr, first, second) {
    if (!Array.isArray(arr)) {
       return NaN;
    }
    if (first < 0) {
        first = 0;
    }
    if (second > arr.length - 1) {
        second = arr.length - 1;
    }

    let slicing = arr.slice(first, second + 1);
    let sum = slicing.reduce((a, b) => a + Number(b), 0);

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve('text', 0, 2));