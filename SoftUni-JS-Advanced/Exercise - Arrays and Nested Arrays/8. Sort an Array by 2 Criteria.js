function solve(theArray) {
    let result = theArray.sort();
 return result.sort(function(a, b){return a.length -b.length});
}

console.log(solve(['Isacc', 'Theodor','Jack', 'Harrison', 'George']));