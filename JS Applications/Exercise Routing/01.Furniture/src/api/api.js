export const url = 'http://localhost:3030';

export function registerRequest(email, password) {
    const result = fetch(url + '/users/register', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    }).then(x => x.json())

    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
}
export function loginRequest(email, password) {
    const result = fetch(url + '/users/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    }).then(x => x.json());

    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('email', result.email);
    sessionStorage.setItem('authToken', result.accessToken);
}

export function logoutRequest() {
    const result = fetch(url + '/users/logout')
        .then(x => x.json());

    sessionStorage.removeItem('userId', result._id);
    sessionStorage.removeItem('email', result.email);
    sessionStorage.removeItem('authToken', result.accessToken);
}

export function createRequest(body) {
    fetch(url + '/data/catalog',{
        method: 'post',
        headers: {'Content-Type':'application/json'},
        body: JSON.stringify(body)
    }).then(x => x.json());


    //sessionStorage.setItem('itemId', result._id);
}

export function myPublicationsRequest() {
    // const result = fetch(url + `data/catalog?where=_ownerId%3D%22${id}%22`)
    //     .then(x => x.json())
}
export async function dashboardRequest() {
    const result = await fetch(url + `/data/catalog`)
        .then(x => x.json())

        return result;
}