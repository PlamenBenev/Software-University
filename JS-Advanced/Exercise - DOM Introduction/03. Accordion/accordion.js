function toggle() {
    let extra = document.getElementById('extra');
    let button = document.querySelector('.button');
    let state = button.textContent == 'LESS';

    if (state){
        extra.style.display = 'none';
        button.textContent = 'MORE';
    } else if (!state){
        extra.style.display = 'inline';
        button.textContent = 'LESS';
     }
}