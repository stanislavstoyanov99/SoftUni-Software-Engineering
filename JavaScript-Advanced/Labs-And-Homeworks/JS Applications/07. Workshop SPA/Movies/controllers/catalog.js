import { getMovies, getMoviesByOwner } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function allMovies() {
    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/catalog/movie.hbs')
    };

    const searchInput = this.params.search || '';
    const data = {};

    try {
        notifications.showLoader();
        const allMovies = await getMovies(token, searchInput);

        if (allMovies.length === 0) {
            notifications.showNotification('There are not any results matching your criteria.', 'info');
            this.redirect('#/catalog');
        }

        data.movies = allMovies.sort((m1, m2) => m2.tickets - m1.tickets);

        if (data.movies.code) {
            throw data.movies;
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');  
    }

    Object.assign(data, { origin: encodeURIComponent('#/catalog'), search: searchInput}, this.app.userData);

    this.partial('./templates/catalog/allMovies.hbs', data);
}

export async function myMovies() {
    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        myMovie: await this.load('./templates/catalog/myMovie.hbs')
    };

    const data = {};

    try {
        notifications.showLoader();
        data.myMovies = (await getMoviesByOwner(localStorage.getItem('userId'), token))
            .sort((m1, m2) => m2.tickets - m1.tickets);

        if (data.myMovies.code) {
            throw data.movies;
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');  
    }

    Object.assign(data, { origin: encodeURIComponent('#/catalog/myMovies')}, this.app.userData);

    this.partial('./templates/catalog/myMovies.hbs', data);
}