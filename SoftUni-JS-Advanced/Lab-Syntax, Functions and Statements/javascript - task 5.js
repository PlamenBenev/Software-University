function asd(first,second,symbol){
    let result;
    if (symbol === '+'){
        result = first + second;
    } else if (symbol === '-'){
        result = first - second;
    } else if (symbol === '*'){
        result = first * second;
    } else if (symbol === '/'){
        result = first / second;
    } else if (symbol === '%'){
        result = first % second;
    } else if (symbol === '**'){
        result = first ** second;
    }
    console.log(result);
}
asd(3, 5.5, '*');
