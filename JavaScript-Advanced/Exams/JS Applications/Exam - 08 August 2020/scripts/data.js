import API from './api.js';

const appId = 'D1BF41E2-E746-D72E-FFD0-EB80F1DAF900';
const restApiKey = '28BBC50B-815D-4908-BE31-F0E7C7ACFBBA';

const endpoints = {
    MOVIES: 'data/movies'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreateMovie(movie) {
    return api.post(endpoints.MOVIES, movie);
}

export async function apiEditMovie(editedMovie, id) {
    return api.put(endpoints.MOVIES + '/' + id, editedMovie);
}

export async function apiDeleteMovie(id) {
    return api.delete(endpoints.MOVIES + '/' + id);
}

export async function getMovieById(id) {
    return api.get(endpoints.MOVIES + '/' + id);
}

export async function getAllMovies() {
    return api.get(endpoints.MOVIES);
}

export async function getMoviesBySearchCriteria(movieTitle) {
    const endpoint = endpoints.MOVIES + `?where=${escape(`movieTitle LIKE '%${movieTitle}%'`)}`;

    return api.get(endpoint);
}

export async function getMovies(searchedMovieTitle) {
    if (searchedMovieTitle) {
        return await getMoviesBySearchCriteria(searchedMovieTitle);
    } else {
        return await getAllMovies();
    }
}

export async function likeMovie(movie, id, email) {
    if (!movie.people.includes(email)) {
        movie.people.push(email);
    } else {
        throw new Error('You already liked this movie.');
    }

    return await apiEditMovie(movie, id);
}