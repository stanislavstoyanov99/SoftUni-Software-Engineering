import { createMovie, getMovieById, buyTicket  } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function createGet() {
    notifications.showLoader();

    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/movies/createForm.hbs', this.app.userData);
    notifications.hideLoader();
}

export async function createPost() {
    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    if (!this.params.genres ||
         !this.params.image ||
          !this.params.tickets ||
           !this.params.title ||
            !this.params.description) {
        notifications.showNotification('All input fields are required.', 'error');
        return;
    }

    if (this.params.title.length < 6) {
        notifications.showNotification('The title should be at least 6 characters long.', 'error');
        return;
    }

    if (this.params.description.length < 10) {
        notifications.showNotification('The description should be at least 10 characters long.', 'error');
        return;
    }

    if (!this.params.image.startsWith('https://')) {
        notifications.showNotification('The image should start with https://"', 'error');
        return;
    }

    if (isNaN(this.params.tickets)) {
        notifications.showNotification('The available tickets should be a number.', 'error');
        return;
    }
    
    const movie = {
        title: this.params.title,
        description: this.params.description,
        genres: this.params.genres,
        image: this.params.image,
        tickets: Number(this.params.tickets)
    };

    try {
        notifications.showLoader();
        const createdMovie = await createMovie(movie, token);

        if (createdMovie.code) {
            throw createdMovie;
        }

        notifications.hideLoader();
        notifications.showNotification(`Movie with title ${movie.title} has been created successfully.`, 'info');

        this.redirect(`#/catalog`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function detailsGet() {
    const token = validateToken(this);
    
    if (!token) {
        return;
    }

    const data = Object.assign({}, this.app.userData);
    data.movie = {};

    try {
        notifications.showLoader();
        data.movie = await getMovieById(this.params.id, token);

        if (data.movie.code) {
            throw data.movie;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/movies/details.hbs', data);
    notifications.hideLoader();
}

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

        await buyTicket(movie, token);

        notifications.hideLoader();
        notifications.showNotification(`Successfully bought ticket for ${movie.title}`, 'info');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.redirect('#/catalog');
}