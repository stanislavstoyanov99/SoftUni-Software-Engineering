import { getAllMovies, getMoviesByOwner } from '../scripts/data.js';
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

    const data = Object.assign({}, this.app.userData);
    data.movies = [];

    try {
        notifications.showLoader();
        data.movies = await getAllMovies(token);

        if (data.movies.code) {
            throw data.movies;
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');  
    }


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

    const data = Object.assign({}, this.app.userData);
    data.myMovies = [];

    try {
        notifications.showLoader();
        data.myMovies = await getMoviesByOwner(data.userId, token);

        if (data.myMovies.code) {
            throw data.movies;
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');  
    }


    this.partial('./templates/catalog/myMovies.hbs', data);
}