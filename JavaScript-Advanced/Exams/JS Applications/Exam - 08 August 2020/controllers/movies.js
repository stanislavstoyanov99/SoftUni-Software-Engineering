import { apiCreateMovie, apiDeleteMovie, apiEditMovie, getMovieById, likeMovie } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';
import validateErrors from '../scripts/validateErrors.js';

export async function createMovieGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/movies/create.hbs', this.app.userData);
}

export async function createMoviePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const errors = validateErrors(this);
    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const movie = {
        movieTitle: this.params.title,
        description: this.params.description,
        imageUrl: this.params.imageUrl,
        people: [],
        creator: this.app.userData.email
    };

    try {
        const createdMovie = await apiCreateMovie(movie);

        if (createdMovie.code) {
            throw createdMovie;
        }

        notifications.showNotification('Created successfully!', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function editMovieGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let movie = {};

    try {
        movie = await getMovieById(this.params.id);

        if (movie.code) {
            throw movie;
        }
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    Object.assign(movie, this.app.userData);

    await this.partial('./templates/movies/edit.hbs', movie);
}

export async function editMoviePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const errors = validateErrors(this);
    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const movie = {
        movieTitle: this.params.title,
        description: this.params.description,
        imageUrl: this.params.imageUrl
    };

    try {
        const editedMovie = await apiEditMovie(movie, this.params.id);

        if (editedMovie.code) {
            throw editedMovie;
        }

        notifications.showNotification('Edited successfully', 'info');

        this.redirect(`#/details/${this.params.id}`);
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function deleteMovieGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        const deletionTime = await apiDeleteMovie(this.params.id);

        if (deletionTime.code) {
            throw deletionTime;
        }

        notifications.showNotification('Deleted successfully', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function likeMovieGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let movie = {};

    try {
        movie = await getMovieById(this.params.id);

        if (movie.code) {
            throw movie;
        }

        if (movie.creator === this.app.userData.email) {
            throw new Error('You cannot like movie created by you.');
        }

        const likedMovie = await likeMovie(movie, this.params.id, this.app.userData.email);

        if (likedMovie.code) {
            throw likedMovie;
        }

        notifications.showNotification('Liked successfully', 'info');
        this.redirect(`#/details/${this.params.id}`);
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function detailsGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let movie = {};

    try {
        movie = await getMovieById(this.params.id);

        if (movie.code) {
            throw movie;
        }

        if (movie.creator === this.app.userData.email) {
            movie.isCreator = true;
        } else {
            movie.isCreator = false;
        }
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    movie.likes = movie.people.length;

    if (movie.people.includes(this.app.userData.email)) {
        movie.isLiked = true;
    } else {
        movie.isLiked = false;
    }

    Object.assign(movie, this.app.userData);

    this.partial('./templates/movies/details.hbs', movie);
}