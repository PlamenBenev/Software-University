function colorize() {
    let a = document.querySelectorAll('tr');

    for (let i = 1; i < a.length; i+=2) {
        a[i].style.backgroundColor = 'teal';
    }

    console.log(a);
}