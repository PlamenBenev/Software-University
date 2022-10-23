 function asd(input){
    let array = [];
    for (let index = 0; index < input.length; index++) {
        array[index] = input[index];       
    }
    return Number(array[0]) + Number(array[array.length - 1]);
}
console.log(asd(['5', '10']));
