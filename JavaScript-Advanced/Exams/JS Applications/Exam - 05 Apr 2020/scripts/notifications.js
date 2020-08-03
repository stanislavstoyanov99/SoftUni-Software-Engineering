const notifications = {
    loading: document.querySelector('#loadingBox'),
    info: document.querySelector('#infoBox'),
    error: document.querySelector('#errorBox')
};

export function showNotification(message, type) {
    // Default behaviour if type is not provided
    if (!type) {
        type = 'info';
    }

    notifications[type].children[0].textContent = message;
    notifications[type].style.display = 'block';

    setTimeout(() => hideNotification(notifications[type]), 5000);
}

export function showLoader() {
    notifications.loading.style.display = 'block';
}

export function hideLoader() {
    notifications.loading.style.display = 'none';
}

function hideNotification(notification) {
    notification.children[0].textContent = '';
    notification.style.display = 'none';
}