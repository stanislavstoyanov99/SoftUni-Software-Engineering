import { login, register, logout, getEventsByOrganizer } from '../scripts/data.js';
import validateUser from '../scripts/validateUser.js';
import * as notifications from '../scripts/notifications.js';

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
        username: this.params.username,
        password: this.params.password
    };

    try {
        notifications.showLoader();
        const loggedUser = await login(user.username, user.password);

        localStorage.setItem('username', loggedUser.user.email);
        localStorage.setItem('userId', loggedUser.user.uid);

        this.app.userData.username = loggedUser.user.email;
        this.app.userData.userId = loggedUser.user.uid;

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
        await register(user.username, user.password);

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
    if (!validateUser()) {
        return;
    }

    try {
        notifications.showLoader();
        await logout();

        localStorage.clear();
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
    if (!validateUser()) {
        return;
    }
    
    let events = {};

    try {
        notifications.showLoader();
        events = await getEventsByOrganizer(this.app.userData.username);

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }

    const data = {
        events: events.map(e => e.name),
        eventsCount: events.length
    };

    Object.assign(data, this.app.userData);

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/users/profile.hbs', data);
}