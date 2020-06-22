function notify(message) {
    const notificationMessage = document.getElementById('notification');

    notificationMessage.textContent = message;
    notificationMessage.style.display = 'block';

    let intervalID = setTimeout(
        function () {
            notificationMessage.style.display = 'none';
            clearTimeout(intervalID);
        }, 2000);
}