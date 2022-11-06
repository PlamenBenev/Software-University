export const url = 'http://localhost:3030';

export function registerRequest(email, password) {
    const requestBody = getOptions('post', { email, password })

    const result = request(url + '/users/register', requestBody)
        .then(x => {
            sessionStorage.setItem('userId', x._id);
            sessionStorage.setItem('email', x.email);
            sessionStorage.setItem('authToken', x.accessToken);
        })

    return result;
}
export function loginRequest(email, password) {
    const requestBody = getOptions('post', { email, password })

    const result = request(url + '/users/login', requestBody)
        .then(x => {
            sessionStorage.setItem('userId', x._id);
            sessionStorage.setItem('email', x.email);
            sessionStorage.setItem('authToken', x.accessToken);
        })

    return result;
}

export function logoutRequest() {
    const requestBody = getOptions('delete')

    const result = request(url + '/users/logout', requestBody)
        .then(x => {
            sessionStorage.removeItem('userId', x._id);
            sessionStorage.removeItem('email', x.email);
            sessionStorage.removeItem('authToken', x.accessToken);
        })

    return result;
}

export function createRequest(body) {
    const requestBody = getOptions('post', body)

    const result = request(url + '/data/catalog', requestBody)
        .then(x => {
            sessionStorage.setItem('itemId',x._id);
        })

    return result;
}

export function myPublicationsRequest() {
    const id = sessionStorage.getItem('userId')
    const result = request(url + `/data/catalog?where=_ownerId%3D%22${id}%22`)

    return result;
}

export function dashboardRequest() {
    const result = request(url + `/data/catalog`)

    return result;
}

export function detailsRequest(id){
    const result = request(url + `/data/catalog/` + id)

    return result;
}
export function editRequest(id,body){
    const requestBody = getOptions('put',body)
    const result = request(url + `/data/catalog/` + id, requestBody)

    return result;
}
export function deleteRequest(id){
    const requestBody = getOptions('delete')
    const result = request(url + `/data/catalog/` + id, requestBody)

    return result;
}

async function request(url, options) {
    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            return await response.json();
        } catch (err) {
            return response;
        }
    } catch (err) {
        alert(err.message);
        throw err;
    }
}

function getOptions(method = 'get', body) {
    const options = {
        method,
        headers: {},
    };

    const token = sessionStorage.getItem('authToken');
    //console.log(token);
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}