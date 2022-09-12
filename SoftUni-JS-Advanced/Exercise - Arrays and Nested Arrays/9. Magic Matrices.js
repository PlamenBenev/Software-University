function solve(theArray) {
    let theValue;
    let isitequial = true;
    for (let r = 0; r < theArray.length; r++) {
        let currentSum = theArray[r].reduce((a,b) => a+b);

        if (theValue == undefined){
            theValue = currentSum;
        } else if (currentSum != theValue){
            isitequial = false;
            break;
        }
    }
    return isitequial;
}

console.log(solve(
    [[1, 0, 0], [0, 0, 1], [0, 1, 0]]));