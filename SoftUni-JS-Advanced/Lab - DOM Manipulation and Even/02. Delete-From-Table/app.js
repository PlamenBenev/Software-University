function deleteByEmail() {
    let elements = document.querySelectorAll('tbody tr');
    let input = document.querySelector('input');
    let result = document.getElementById('result');

    for (const items of elements) {
        let data = items.querySelectorAll('td');

        if (data[1].textContent == input.value){
            items.remove();
            result.textContent = 'Deleted';
        } else {result.textContent = 'Not found.';}
    }
}