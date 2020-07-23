import { login } from '../scripts/data.js';
import { register } from '../scripts/data.js';
import { logout } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export async function loginGet() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        loginForm: await this.load('./templates/login/loginForm.hbs')
    };

    this.partial('./templates/login/loginPage.hbs', this.app.userData);
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

        this.app.userData.loggedIn = true;
        this.app.userData.username = loggedUser.username;
        this.app.userData.userId = loggedUser.objectId;

        if (loggedUser.teamId) {
            this.app.userData.hasTeam = true;
            this.app.userData.teamId = loggedUser.teamId;
        }
        
        localStorage.setItem('userToken', loggedUser['user-token']);
        localStorage.setItem('username', loggedUser.username);
        localStorage.setItem('userId', loggedUser.objectId);

        notifications.showNotification('Successful login!', 'info');
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
        registerForm: await this.load('/templates/register/registerForm.hbs')
    };

    this.partial('./templates/register/registerPage.hbs', this.app.userData);
}

export async function registerPost() {
    if (this.params.username.length < 3) {
        notifications.showNotification('Username should be at least 2 symbols', 'error');
        return;
    }

    if (this.params.password.length < 3) {
        notifications.showNotification('Password should be at least 3 symbols', 'error');
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

        notifications.showNotification('Successful registration', 'info');
        this.redirect('#/login');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function logoutGet() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }

    try {
        const logoutUser = await logout();

        if (logoutUser.code) {
            throw logoutUser;
        }

        this.app.userData.hasTeam = false;
        this.app.userData.loggedIn = false;
        this.app.userData.username = undefined;
        this.app.userData.userId = undefined;
        this.app.userData.teamId = undefined;
        
        localStorage.removeItem('userToken');
        localStorage.removeItem('username');
        localStorage.removeItem('userId');

        notifications.showNotification('Successful logout', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
        this.redirect('#/home');
    }
}