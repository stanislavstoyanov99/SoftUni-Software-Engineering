import { login, register, logout } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/users/loginForm.hbs')
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
        const loggedUser = await login(user);

        if (loggedUser.code) {
            throw loggedUser;
        }

        this.app.userData.username = loggedUser.username;
        this.app.userData.userId = loggedUser.objectId;

        localStorage.setItem('userToken', loggedUser['user-token']);
        localStorage.setItem('username', loggedUser.username);
        localStorage.setItem('userId', loggedUser.objectId);

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
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('/templates/users/registerForm.hbs')
    };

    this.partial('./templates/users/register.hbs', this.app.userData);
}

export async function registerPost() {
    if (this.params.username.length < 3) {
        notifications.showNotification('Username should be at least 3 symbols', 'error');
        return;
    }

    if (this.params.password.length < 6) {
        notifications.showNotification('Password should be at least 6 symbols', 'error');
        return;
    }

    if (this.params.password !== this.params.repeatPassword) {
        notifications.showNotification('Passwords do not match', 'error');
        return;
    }

    const user = {
        username: this.params.username,
        password: this.params.password
    };

    try {
        const registeredUser = await register(user);

        if (registeredUser.code) {
            throw registeredUser;
        }

        notifications.showNotification('User registration successful.', 'info');
        await login(user);
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

        this.app.userData.username = undefined;
        this.app.userData.userId = undefined;
        
        localStorage.removeItem('userToken');
        localStorage.removeItem('username');
        localStorage.removeItem('userId');

        notifications.showNotification('Logout successful.', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }
}