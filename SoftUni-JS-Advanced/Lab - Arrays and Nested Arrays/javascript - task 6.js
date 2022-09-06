 function asd(input){
    let array = [];
    for (let index = 0; index < input.length; index++) {
        array[index] = input[index];
    }
    let result = [];

    array.sort((a, b) => a - b);

    if (array.length % 2 != 0){
        for (let index = (input.length - 1) / 2; index < input.length; index++) {
            result.push(array[index]);
        }
    } else {
        for (let index = (input.length ) / 2; index < input.length; index++) {
            result.push(array[index]);
        }
    }
    
    console.log(result);
}
asd([3, 19, 14, 7, 2, 19, 6]);
