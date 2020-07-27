import { getMovieById, buyTicket  } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function buyTicketGet() {
    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    try {
        notifications.showLoader();
        const movie = await getMovieById(this.params.id, token);

        if (movie.code) {
            throw movie;
        }

        const updatedMovie = await buyTicket(movie, token);
        if (updatedMovie.code) {
            throw updatedMovie;
        }

        notifications.hideLoader();
        notifications.showNotification(`Successfully bought ticket for ${movie.title}`, 'info');

        console.log(this.params.origin);
        if (this.params.search) {
            this.redirect(this.params.origin + `?search=${this.params.search}`);
        } else {
            this.redirect(this.params.origin);
        }
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}