import { login, register, logout } from '../scripts/data.js';
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
    if (!this.params.email || !this.params.password) {
        notifications.showNotification('Email or password is incorrect.', 'error');
        return;
    }

    const user = {
        login: this.params.email,
        password: this.params.password
    };

    try {
        const loggedUser = await login(user);

        if (loggedUser.code) {
            throw loggedUser;
        }

        this.app.userData.email = loggedUser.email;
        this.app.userData.userId = loggedUser.objectId;

        notifications.showNotification('Login successful.', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
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

    if (!this.params.email ||
        !this.params.password ||
         !this.params.repeatPassword) {
        errors.push('All input fields are required.');
    }

    if (this.params.password.length < 6) {
        errors.push('Password should be at least 6 characters.');
    }

    if (this.params.password !== this.params.repeatPassword) {
        errors.push('Passwords do not match.');
    }

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const user = {
        email: this.params.email,
        password: this.params.password
    };

    try {
        const registeredUser = await register(user);

        if (registeredUser.code) {
            throw registeredUser;
        }

        notifications.showNotification('Successful registration!', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function logoutGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        const logoutUser = await logout();

        if (logoutUser.code) {
            throw logoutUser;
        }

        this.app.userData.email = undefined;
        this.app.userData.userId = undefined;

        notifications.showNotification('Successful logout', 'info');

        this.redirect('#/login');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
        this.redirect('#/login');
    }
}