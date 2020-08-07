import * as notifications from '../scripts/notifications.js';

export default function () {
    if (!localStorage.getItem('username')) {
        notifications.showNotification('You must be logged in.', 'error');
        notifications.hideLoader();
        return false;
    }

    return true;
}