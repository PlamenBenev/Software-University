function asd(first){
    let result;
    if (first === 'Monday'){
        result = 1;
    } else if (first === 'Tuesday'){
        result = 2;
    } else if (first === 'Wednesday'){
        result = 3;
    } else if (first === 'Thursday'){
        result = 4;
    } else if (first === 'Friday'){
        result = 5;
    } else if (first === 'Saturday'){
        result = 6;
    } else if (first === 'Sunday'){
        result = 7;
    } else {
        result = 'error';
    }
    console.log(result);
}
asd('Monday');
