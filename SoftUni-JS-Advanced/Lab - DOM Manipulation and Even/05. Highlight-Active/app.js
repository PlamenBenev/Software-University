function focused() {
    let focus = document.querySelectorAll('input');

    const focused = (e) => {
        e.parentNode.className = 'focused';
    }
    const blurred = (e) => {
        e.parentNode.className = 'blurred';
    }

    for (const items of focus) {
        items.addEventListener('focus', e => focused(e.target));
        items.addEventListener('blur', e => blurred(e.target));
    }
}