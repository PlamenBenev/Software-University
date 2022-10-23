 function asd(first){
    let word = String(first);
    let result = true;;
    for (let index = 1; index < word.length; index++) {
        if (word[index] !== word[index-1])
        {
            result = false;
            break;
        }
    }
    console.log(result);
}
asd(2232222);
