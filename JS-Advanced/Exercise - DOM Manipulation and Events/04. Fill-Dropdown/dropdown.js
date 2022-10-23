function addItem() {
    let menu = document.getElementById('menu');
    let inputs = document.querySelectorAll('input');

 //   inputs[2].onclick = function(){
        let option = document.createElement('option');
        option.textContent = inputs[0].value;
        option.value = inputs[1].value;
        menu.appendChild(option);

        inputs[0].value = '';
        inputs[1].value = '';
        console.log(menu);
  //  }
}