function sumTable() {
    let a = document.getElementsByTagName('tr');
    let theSum = 0;
    for (let i = 1; i < a.length -1; i++) {
        theSum += Number(a[i].lastChild.textContent);
    }
    let sumDoc = document.getElementById('sum');
    sumDoc.textContent = theSum;
    console.log(theSum);
}