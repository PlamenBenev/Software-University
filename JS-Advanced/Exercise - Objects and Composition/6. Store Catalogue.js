function result(param) {
    let sorting = param.sort();
    let arr = [];
    for (const item of sorting) {
        arr.push(item.split(" : ").join(": "));
    }

    console.log(arr[0][0]);
    console.log("  " + arr[0]);
for (let i = 1; i < arr.length; i++) {
        if (arr[i][0] != arr[i-1][0]){
            console.log(arr[i][0]);
        }
        console.log("  " + arr[i]);
}

}
result(['Appricot : 20.4','Fridge : 1500', 'TV : 1499', 'Deodorant : 10', 'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);