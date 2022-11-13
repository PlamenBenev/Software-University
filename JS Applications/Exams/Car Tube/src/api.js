const url = 'http://localhost:3030'

export function logoutRequest() {
    const getOption = getOptions('get')
    const result = request(url + '/users/logout', getOption)
        .then(x => {
            sessionStorage.removeItem('userId', x._id);
            sessionStorage.removeItem('authToken', x._ownerId);
        })

    return result;
}
export function registerRequest(body) {
    const getOption = getOptions('post', body);
    const result = request(url + '/users/register', getOption)
        .then(x => {
            sessionStorage.setItem('username', x.username);
            sessionStorage.setItem('userId', x._id);
            sessionStorage.setItem('authToken', x.accessToken);
        })

    return result;
}
export function loginRequest(body) {
    const getOption = getOptions('post', body);
    const result = request(url + '/users/login', getOption)
        .then(x => {
            sessionStorage.setItem('username', x.username);
            sessionStorage.setItem('userId', x._id);
            sessionStorage.setItem('authToken', x.accessToken);
        })

    return result;
}

export function allListingsRequest() {
    const getOption = getOptions('get');
    const result = request(url + `/data/cars?sortBy=_createdOn%20desc`, getOption);

    return result;
}
export function createRequest(body) {
    const getOption = getOptions('post', body);
    const result = request(url + `/data/cars`, getOption);

    return result;
}
export function detailsRequest(id) {
    const getOption = getOptions('get');
    const result = request(url + `/data/cars/` + id, getOption);

    return result;
}
export function deleteRequest(id) {
    const getOption = getOptions('delete');
    const result = request(url + `/data/cars/` + id, getOption);

    return result;
}

export function editRequest(id, body) {
    const getOption = getOptions('put', body);
    const result = request(url + `/data/cars/` + id, getOption);

    return result;
}

export function myListingsRequest(userId) {
    const getOption = getOptions('get');
    const result = request(url + `/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`, getOption);

    return result;
}

export function searchRequest(query) {
    const getOption = getOptions('get');
    const result = request(url + `/data/cars?where=year%3D${query}`, getOption);

    return result;
}

async function request(url, options) {
    try {
        const x = await fetch(url, options);
        if (!x.ok) {
            const error = await x.json();
            throw new Error(error.message);
        }
        try {
            return await x.json();
        } catch (err) {
            return x;
        }
    } catch (error) {
        alert(error.message);
        throw error;
    }
}

function getOptions(method = 'get', body) {
    const options = {
        method,
        headers: {}
    }

    const token = sessionStorage.getItem('authToken');

    if (token) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}