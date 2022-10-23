 function asd(first){
    let array = first;
    let result = first[0] + ' ';
    for (let index = 2; index < array.length; index += 2) {
        result += array[index] + ' ';     
    }
    console.log(result);
}
asd(['5', '10']);
