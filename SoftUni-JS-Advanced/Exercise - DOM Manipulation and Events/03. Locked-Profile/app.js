function lockedProfile() {
    let profiles = document.getElementsByClassName('profile');
    let button = profiles[0].querySelector('button');

    for (const element of profiles) {
        let button = element.querySelector('button');
        let info = element.querySelector('div');
        let radios = element.querySelectorAll('input')[1];

        button.addEventListener('mousedown', (e) => {
            if (radios.checked && info.style.display != 'inline'){
                info.style.display = 'inline';
                button.innerHTML = 'Hide it';
            } else if (radios.checked && info.style.display == 'inline'){
                info.style.display = 'none';
                button.innerHTML = 'Show more';
            }
        });
    }
}