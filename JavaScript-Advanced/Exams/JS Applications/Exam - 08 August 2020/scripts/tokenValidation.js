import * as notifications from './notifications.js';

export function validateToken(app) {
    const token = localStorage.getItem('userToken');

    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        app.redirect('#/login');
        return;
    }

    return token;
}