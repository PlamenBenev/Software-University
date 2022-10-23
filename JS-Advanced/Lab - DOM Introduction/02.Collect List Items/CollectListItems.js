function extractText() {
    let theId = document.getElementById('items');
    let theResult = document.getElementById("result");
    
    theResult.textContent = theId.textContent;
}