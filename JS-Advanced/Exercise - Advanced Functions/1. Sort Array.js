function solve(array, order) {
    let arr = array;

    if (order == 'asc'){
        arr.sort((a,b) => a - b);
    } else if (order == 'desc'){
        arr.sort((a,b) => b - a);
    }
    console.log(arr);
}

solve([14, 7, 17, 6, 8], 'desc');