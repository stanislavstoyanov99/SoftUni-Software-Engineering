import { login, register, logout, getEventsByUserId } from '../scripts/data.js';
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
        notifications.showNotification('Login successful.', 'info');
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
    if (!this.params.password || !this.params.username) {
        notifications.showNotification('All input fields are required', 'error');
        return;
    }

    if (this.params.username.length < 3) {
        notifications.showNotification('Username should be at least 3 characters', 'error');
        return;
    }

    if (this.params.password.length < 6) {
        notifications.showNotification('Password should be at least 6 characters', 'error');
        return;
    }

    if (this.params.password !== this.params.rePassword) {
        notifications.showNotification('Passwords do not match', 'error');
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
        notifications.showNotification('User registration successful.', 'info');
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

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }
}

export async function profileGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let data = {};

    try {
        notifications.showLoader();
        data.events = await getEventsByUserId(this.app.userData.userId);

        if (data.events.code) {
            throw userEvents;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }

    Object.assign(data, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/profile.hbs', data);
}