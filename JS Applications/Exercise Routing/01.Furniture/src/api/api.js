const url = 'http://localhost:3030'

export const registerAuth = (email,password) => {
    return fetch(url + '/users/register', {
        method: 'post',
        headers: {'Content-Type':'application/json'},
        body: JSON.stringify({email,password})
    }).then(x => x.json());
}

export const loginAuth = (email,password) => {
    return fetch(url + '/users/login', {
        method: 'post',
        headers: {'Content-Type':'application/json'},
        body: JSON.stringify({email,password})
    }).then(x => x.json());
}