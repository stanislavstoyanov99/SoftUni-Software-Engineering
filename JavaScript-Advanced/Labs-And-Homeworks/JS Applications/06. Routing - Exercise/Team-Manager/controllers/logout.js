import { logout } from '../scripts/data.js';

export default async function() {
    try {
        const result = await logout();

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.loggedIn = false;
        this.app.userData.username = undefined;
        this.app.userData.userId = undefined;
        localStorage.removeItem('userToken', result['user-token']);
        localStorage.removeItem('username', result.username);
        localStorage.removeItem('userId', result.objectId);

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        alert(`Error: ${error.message}`); 
    }
}