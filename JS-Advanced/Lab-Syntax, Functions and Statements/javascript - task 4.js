function asd(first){
    let result;
    if (typeof(first) === 'number')
    {
        result = Math.pow(first,2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else {
        result = 'We can not calculate the circle area, because we receive a string.';
        console.log(result);
    }
}
asd(5);
asd('adgad');
