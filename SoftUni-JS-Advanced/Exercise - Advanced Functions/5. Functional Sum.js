function add(input){
    let sum = 0;
    sum += input;

    function calc(params){
        sum += params;
        return calc;
    }
    calc.toString = () => sum;
    return calc;
}

console.log(add(2)(3).toString());