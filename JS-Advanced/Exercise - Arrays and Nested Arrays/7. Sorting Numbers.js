function solve(theArray) {
    let arr = [];
    
    for (let i = 0; i < theArray.length / 2; i++) {
        let inscending = theArray.sort(function(a, b){return a-b});
        arr.push(inscending[i]);
         let reversing = inscending.reverse();
        arr.push(reversing[i]);
    }
    return arr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));