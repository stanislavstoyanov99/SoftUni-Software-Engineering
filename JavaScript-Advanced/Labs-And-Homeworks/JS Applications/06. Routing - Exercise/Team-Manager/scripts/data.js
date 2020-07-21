const appKey = 'E8F9CD15-006F-B933-FFE1-3366368C2200';
const restKey = 'E0D6E103-F752-4A13-A1A1-469B62D7EC89';

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    TEAMS: 'data/teams',
    UPDATE_USER: 'users/',
    LOGOUT: 'users/logout'
};

export async function register(username, password) {
    return (await fetch(host(api.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ 
            username,
            password 
        })
    })).json();
}

export async function login(username, password) {
    return (await fetch(host(api.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ 
            login: username,
            password 
        })
    })).json();
}

export async function logout() {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in.');
    }

    return fetch(host(api.LOGOUT), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    });
}

async function setUserTeamId(userId, teamId) {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in.');
    }
    
    return (await fetch(host(api.UPDATE_USER + userId), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({
            teamId
        })
    })).json();
}

export async function createTeam(team) {
    const token = localStorage.getItem('userToken');

    if (!token) {
        throw new Error('User is not logged in.');
    }

    const result = await (await fetch(host(api.TEAMS), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (result.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }

    // Assign teamId to user
    const userUpdateResult = await setUserTeamId(result.ownerId, result.objectId);

    if (userUpdateResult.hasOwnProperty('errorData')) {
        const error = new Error();
        Object.assign(error, result);
        throw error;
    }

    return result;
}