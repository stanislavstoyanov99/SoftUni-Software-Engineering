const notifications = {
    loading: document.querySelector('#loadingBox'),
    info: document.querySelector('#infoBox'),
    error: document.querySelector('#errorBox')
};

notifications.error.addEventListener('click', (e) => hideNotification(e.currentTarget));
notifications.info.addEventListener('click', (e) => hideNotification(e.currentTarget));

export function showNotification(message, type) {
    // Default behaviour if type is not provided
    if (!type) {
        type = 'info';
    }

    notifications[type].children[0].textContent = message;
    notifications[type].style.display = 'block';

    if (type === 'info') {
        setTimeout(() => hideNotification(notifications['info']), 3000);
    }
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