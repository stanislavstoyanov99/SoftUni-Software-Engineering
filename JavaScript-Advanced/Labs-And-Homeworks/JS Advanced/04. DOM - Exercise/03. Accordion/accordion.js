function toggle() {
    const button = document.querySelector('.head > .button');
    const divExtra = document.querySelector('#extra');

    if (divExtra.style.display === 'none' && button.textContent === 'More') {
        divExtra.style.display = 'block';
        button.textContent = 'Less';
    } else {
        divExtra.style.display = 'none';
        button.textContent = 'More';
    }
}