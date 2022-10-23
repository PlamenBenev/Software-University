function asd(first,second,thirth){
    let result;
    let kilos = Number(second) / 1000;
    let price = kilos * Number(thirth);
    result = 'I need $' + price.toFixed(2) + ' to buy ${kilos}' + kilos.toFixed(2) + ' kilograms ' + first + '.';
    console.log('to buy ${kilos}');
}
asd('apple', 1563, 2.35);
