function notify(message) {
    const notificationMessage = document.getElementById('notification');

    notificationMessage.textContent = message;
    notificationMessage.style.display = 'block';

    setTimeout(
        function () {
            notificationMessage.style.display = 'none';
        }, 2000);
}