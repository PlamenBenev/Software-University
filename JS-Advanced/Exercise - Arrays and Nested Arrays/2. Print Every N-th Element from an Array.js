function solve(theArray,theNum) {
    let arr = [];
    for (let i = 0; i < theArray.length; i += theNum) {
        arr.push(theArray[i]);
    }
    return arr;
}

console.log(solve(['dsa', 'asd', 'test', 'tset'], 2));