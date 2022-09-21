function validate() {
    let regex = /^[a-z]+@[a-z]+.[a-z]+$/;
    let input = document.getElementById('email');

    function validate (e){
        if (!regex.test(e.target.value)){
            e.target.className = 'error';
        } else {
            e.target.className = '';
        }
    }
    input.addEventListener('change',validate);
}