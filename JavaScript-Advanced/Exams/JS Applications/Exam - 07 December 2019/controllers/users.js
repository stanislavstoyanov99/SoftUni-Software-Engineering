import { login, register, logout, getTreksByUserId } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/login.hbs', this.app.userData);
}

export async function loginPost() {
    if (!this.params.username || !this.params.password) {
        notifications.showNotification('Email or password is incorrect.', 'error');
        return;
    }

    const user = {
        login: this.params.username,
        password: this.params.password
    };

    try {
        notifications.showLoader();
        const loggedUser = await login(user);

        if (loggedUser.code) {
            throw loggedUser;
        }

        this.app.userData.username = loggedUser.username;
        this.app.userData.userId = loggedUser.objectId;

        notifications.hideLoader();
        notifications.showNotification('Successfully logged user.', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function registerGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function registerPost() {
    const errors = [];

    if (!this.params.password || !this.params.username) {
        errors.push('All input fields are required.');
    }

    if (this.params.username.length < 3) {
        errors.push('Username should be at least 3 characters.');
    }

    if (this.params.password.length < 6) {
        errors.push('Password should be at least 6 characters.');
    }

    if (this.params.password !== this.params.rePassword) {
        errors.push('Passwords do not match.');
    }

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const user = {
        username: this.params.username,
        password: this.params.password
    };

    try {
        notifications.showLoader();
        const registeredUser = await register(user);

        if (registeredUser.code) {
            throw registeredUser;
        }

        notifications.hideLoader();
        notifications.showNotification('Successfully registered user.', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function logoutGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        notifications.showLoader();
        const logoutUser = await logout();

        if (logoutUser.code) {
            throw logoutUser;
        }

        this.app.userData.username = undefined;
        this.app.userData.userId = undefined;

        notifications.hideLoader();
        notifications.showNotification('Logout successful.', 'info');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.redirect('#/home');
}

export async function profileGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let treks = {};

    try {
        notifications.showLoader();
        treks = await getTreksByUserId(this.app.userData.userId);

        if (treks.code) {
            throw treks;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }

    const data = {
        treks: treks.map(t => t.location),
        treksNumber: treks.length
    };

    Object.assign(data, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/profile.hbs', data);
}