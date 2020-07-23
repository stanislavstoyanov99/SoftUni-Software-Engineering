const notifications = {
    info: document.querySelector('#infoBox'),
    error: document.querySelector('#errorBox')
};

export function showNotification(message, type) {
    // Default behaviour if type is not provided
    if (!type) {
        type = 'info';
    }
    
    notifications[type].textContent = message;
    notifications[type].style.display = 'block';

    notifications[type].addEventListener('click', (e) => {
        hideNotification(e.target);
    });

    setTimeout(() => hideNotification(notifications[type]), 2500);
}

function hideNotification(notification) {
    notification.textContent = '';
    notification.style.display = 'none';
}