 function asd(input){
    let array = [];
    for (let index = 0; index < input.length; index++) {
        array[index] = input[index];
    }
    array.sort();
    console.log(array[0] + ' ' + array[1]);
}
asd([30, 50, 15, 5]);
