import { login, register, logout } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        loginForm: await this.load('./templates/users/loginForm.hbs')
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
        notifications.showLoader();
        const loggedUser = await login(user);

        if (loggedUser.code) {
            throw loggedUser;
        }

        this.app.userData.email = loggedUser.email;
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
        registerForm: await this.load('/templates/users/registerForm.hbs')
    };

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function registerPost() {
    if (this.params.password.length < 6) {
        notifications.showNotification('Password should be at least 6 symbols', 'error');
        return;
    }

    if (this.params.password !== this.params.repeatPassword) {
        notifications.showNotification('Passwords do not match', 'error');
        return;
    }

    const user = {
        email: this.params.email,
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
        this.redirect('#/login');
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

        this.app.userData.email = undefined;
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