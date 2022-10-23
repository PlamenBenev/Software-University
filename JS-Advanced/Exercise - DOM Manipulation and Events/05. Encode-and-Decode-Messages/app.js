function encodeAndDecodeMessages() {
    let main = document.getElementById('main').querySelectorAll('div');
    
    let input = main[0].querySelector('textarea');
    let encButton = main[0].querySelector('button');
    let reciever = main[1].querySelector('textarea');
    let decButton = main[1].querySelector('button');

    encButton.onclick = function(){
        reciever.textContent = '';
        for (let i = 0; i < input.value.length; i++) {
            let ascii = input.value.charCodeAt(i) + 1;
            reciever.textContent += String.fromCharCode(ascii);
        }
        input.value = '';
        
    }
    decButton.onclick = function(){
        let word = [];
        for (let i = 0; i < reciever.textContent.length; i++) {
            let ascii = reciever.textContent.charCodeAt(i) - 1;
            word.push(String.fromCharCode(ascii));
        }
        reciever.textContent = word.join('');
        //input.value = '';
    }
}