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
    MOVIES: 'data/movies'
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
            'user-token': token
        }
    });
}

async function createMovie(movie, token) {
    return await (await fetch(host(api.MOVIES), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(movie)
    })).json(); 
}

async function editMovie(editedMovie, id, token) {
    return await (await fetch(host(api.MOVIES + '/' + id), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(editedMovie)
    })).json();
}

async function deleteMovie(id, token) {
    return await (await fetch(host(api.MOVIES + '/' + id), {
        method: 'DELETE',
        headers: {
            'user-token': token
        }
    })).json();
}

async function buyTicket(movie, token) {
    const newTickets = movie.tickets - 1;
    const movieId = movie.objectId;

    return editMovie({ tickets: newTickets}, movieId, token);
}

async function getMovieByOwner(ownerId, token) {
    return (await fetch(host(api.MOVIES + `where=ownerId%3D%27${ownerId}%27`), {
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    })).json();
}

async function getMovieById(id, token) {
    return await (await fetch(host(api.movie + '/' + id), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    })).json();
}

async function getAllMovies(token) {
    return await (await fetch(host(api.MOVIES), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    })).json();
}