import { getMovies } from '../scripts/data.js';
import { validateToken } from '../scripts/tokenValidation.js';
import * as notifications from '../scripts/notifications.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/home/movie.hbs')
    };

    let data = {};
    Object.assign(data, this.app.userData);

    if (this.app.userData.email) {
        try {
            data.movies = await getMovies();

            if (data.movies.code) {
                throw data.movies;
            }
        } catch (error) {
            notifications.showNotification(error.message, 'error');
        }
    }

    this.partial('./templates/home/home.hbs', data);
}

export async function searchMovieGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        movie: await this.load('./templates/home/movie.hbs')
    };

    const searchInput = this.params.search || '';
    const data = {};

    try {
        data.movies = await getMovies(searchInput);

        if (data.movies.code) {
            throw data.movies;
        }
    } catch (error) {
        notifications.showNotification(error.message, 'error');
    }

    Object.assign(data, { origin: encodeURIComponent('#/search'), search: searchInput }, this.app.userData);

    this.partial('./templates/home/home.hbs', data);
}