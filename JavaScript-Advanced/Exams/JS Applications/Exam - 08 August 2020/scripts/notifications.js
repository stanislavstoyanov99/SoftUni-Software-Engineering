const notifications = {
    info: document.querySelector('#successBox'),
    error: document.querySelector('#errorBox')
};

export function showNotification(message, type) {
    notifications[type].textContent = message;
    notifications[type].parentElement.style.display = 'block';

    setTimeout(() => hideNotification(notifications[type]), 1000);
}

function hideNotification(notification) {
    notification.textContent = '';
    notification.parentElement.style.display = 'none';
}