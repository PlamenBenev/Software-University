 function asd(input){
    let array = [];
    for (let index = 0; index < input.length; index++) {
        if (Number(input[index]) < 0){
            array.unshift(Number(input[index]));
        } else {
            array.push(Number(input[index]));
        }
    }
    array.forEach(element => {
        console.log(element);
    });
}
asd([3, -2, 0, -1]);
