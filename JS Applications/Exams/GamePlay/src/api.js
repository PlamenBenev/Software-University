const url = 'http://localhost:3030'

export function homeRequest(){
    const getOption = getOptions('get')
    const result = request(url + `/data/games?sortBy=_createdOn%20desc&distinct=category`,getOption)
    
    return result;
}

export function registerRequest(body){
    const getOption = getOptions('post',body)
    const result = request(url + `/users/register`,getOption)
    .then(x => {
        console.log(x);
        sessionStorage.setItem('userId',x._id);
        sessionStorage.setItem('authToken',x.accessToken);
    });
    
    return result;
}
export function loginRequest(body){
    const getOption = getOptions('post',body)
    const result = request(url + `/users/login`,getOption)
    .then(x => {
        sessionStorage.setItem('userId',x._id);
        sessionStorage.setItem('authToken',x.accessToken);
    });

    return result;
}

export function logoutRequest(body){
    const getOption = getOptions('get')
    const result = request(url + `/users/logout`,getOption)
    .then(x => {
        sessionStorage.removeItem('userId',x._id);
        sessionStorage.removeItem('authToken',x.accessToken);
    });

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