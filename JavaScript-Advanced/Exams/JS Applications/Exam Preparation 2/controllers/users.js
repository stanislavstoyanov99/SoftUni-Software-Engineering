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
    if (!this.params.username || !this.params.password) {
        notifications.showNotification('Username or password is incorrect.', 'error');
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
        this.app.userData.firstName = loggedUser.firstName;
        this.app.userData.lastName = loggedUser.lastName;

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

    if (!this.params.password ||
         !this.params.username ||
         !this.params.firstName ||
         !this.params.lastName ||
         !this.params.repeatPassword) {
        errors.push('All input fields are required.');
    }

    if (this.params.firstName.length < 2) {
        errors.push('First name should be at least 2 characters.');
    }

    if (this.params.lastName.length < 2) {
        errors.push('Last name should be at least 2 characters.');
    }

    if (this.params.username.length < 3) {
        errors.push('Username should be at least 3 characters.');
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
        firstName: this.params.firstName,
        lastName: this.params.lastName,
        username: this.params.username,
        password: this.params.password
    };

    try {
        notifications.showLoader();
        const registeredUser = await register(user);

        if (registeredUser.code) {
            throw registeredUser;
        }

        const loggedUser = await login({ login: this.params.username, password: this.params.password });
        if (loggedUser.code) {
            throw loggedUser;
        }

        this.app.userData.username = loggedUser.username;
        this.app.userData.userId = loggedUser.objectId;
        this.app.userData.firstName = loggedUser.firstName;
        this.app.userData.lastName = loggedUser.lastName;

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
        this.app.userData.firstName = undefined;
        this.app.userData.lastName = undefined;

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