 function asd(arrinput){
    let array = [];
    let result = [];

    for (var item of arrinput) {
        array.push(item)
    }
    for (let index = 1; index < array.length; index += 2) {
        result.push(array[index] * 2);
    }
    result.reverse();
    console.log(result);
}
asd([3, 0, 10, 4, 7, 3]);
