 function asd(length,n){
    let array = [1];
    for (let i = 1; i < Number(length); i++) {
        let numberToAdd = 0;

        for (let index = i - Number(n); index < array.length; index++) {
           // const element = array[index];
           if (index < 0) {
            index = 0
           }
            numberToAdd += array[index];
        } 
        array[i] = numberToAdd;
    }
    return array;
}
console.log(asd(8,2));
