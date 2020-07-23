const appKey = 'E8F9CD15-006F-B933-FFE1-3366368C2200';
const restKey = 'E0D6E103-F752-4A13-A1A1-469B62D7EC89';

function host(endpoint) {
    return `https://api.backendless.com/${appKey}/${restKey}/${endpoint}`;
}

const api = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    TEAMS: 'data/teams',
    USERS: 'data/Users',
    MEMBERS: '?loadRelations=members'
};

export async function register(user) {
    return (await fetch(host(api.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })).json();
}

export async function login(user) {
    return (await fetch(host(api.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })).json();
}

export async function logout(token) {
    return await fetch(host(api.LOGOUT), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    });
}

export async function createTeam(team, token) {
    const createdTeam = await (await fetch(host(api.TEAMS), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (createdTeam.code) {
        return createdTeam;
    }

    const teamId = createdTeam.objectId;
    const userId = localStorage.getItem('userId');

    const teamMembers = await (await fetch(host(api.TEAMS + `/${teamId}/members`), {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify([userId])
    })).json();

    if (teamMembers.code) {
        return teamMembers;
    }

    await (await fetch(host(api.TEAMS + `/${userId}`), {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({
            teamId: teamId
        })
    })).json();

    return createdTeam;
}

export async function editTeam(editedTeam, id, token) {
    return await (await fetch(host(api.TEAMS + '/' + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(editedTeam)
    })).json();
}

export async function getTeamById(id, token) {
    return await (await fetch(host(api.TEAMS + '/' + id + api.MEMBERS), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    })).json();
}

export async function getTeams(token) {
    return await (await fetch(host(api.TEAMS), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    })).json();
}