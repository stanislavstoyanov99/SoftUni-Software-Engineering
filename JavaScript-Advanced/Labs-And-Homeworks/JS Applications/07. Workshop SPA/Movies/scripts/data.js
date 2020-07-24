const appId = '9AFEBA00-D662-C9E3-FF69-9E58B8BD8500';
const restApiKey = '9720BEFE-DCFA-4D72-AEF0-906495BA8552';

function host(endpoint) {
    return `https://api.backendless.com/${appId}/${restApiKey}/${endpoint}`;
}

const api = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    USERS: 'data/Users',
};

async function register(user) {
    return (await fetch(host(api.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })).json();
}

async function login(user) {
    return (await fetch(host(api.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })).json();
}

async function logout(token) {
    return await fetch(host(api.LOGOUT), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    });
}