import API from './api.js';

const appId = '9AFEBA00-D662-C9E3-FF69-9E58B8BD8500';
const restApiKey = '9720BEFE-DCFA-4D72-AEF0-906495BA8552';

const endpoints = {
    MOVIES: 'data/movies'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function createMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

export async function editMovie(editedMovie, id) {
    return api.put(endpoints.MOVIES + '/' + id, editedMovie);
}

export async function deleteMovie(id) {
    return api.delete(endpoints.MOVIES + '/' + id);
}

export async function buyTicket(movie) {
    if (movie.tickets - 1 >= 0) {
        const newTickets = movie.tickets - 1;
        const movieId = movie.objectId;
        return editMovie({ tickets: newTickets}, movieId);
    } else {
        throw new Error('There are no available tickets');
    }
}

export async function getMoviesByOwner(ownerId) {
    return api.get(endpoints.MOVIES + `?where=ownerId%3D%27${ownerId}%27`);
}

export async function getMovieById(id) {
    return api.get(endpoints.MOVIES + '/' + id);
}

export async function getAllMovies() {
    return api.get(endpoints.MOVIES);
}

export async function getMovies(searchedGenre) {
    if (searchedGenre) {
        return await getMoviesBySearchCriteria(searchedGenre);
    } else {
        return await getAllMovies();
    }
}

export async function getMoviesBySearchCriteria(searchedGenre) {
    const endpoint = endpoints.MOVIES + `?where=${escape(`genres LIKE '%${searchedGenre}%'`)}`;

    return api.get(endpoint);
}