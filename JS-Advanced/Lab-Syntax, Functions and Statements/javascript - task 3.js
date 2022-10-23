function asd(first,second,thirth){
    let array = [first, second,thirth];
    let biggest= null;
    array.forEach(element => {
        if (biggest < element || biggest == null) {
            biggest = element;
        }
    });
    console.log('The largest number is ' + biggest);
}
asd(-3, -5, -22.5);
