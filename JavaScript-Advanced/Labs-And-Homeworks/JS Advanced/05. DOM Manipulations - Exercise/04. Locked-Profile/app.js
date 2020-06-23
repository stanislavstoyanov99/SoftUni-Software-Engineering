function lockedProfile() {
    const buttons = [...document.querySelectorAll('button')];

    buttons.forEach(btn => btn.addEventListener('click', (e) => {
        const btn = e.target;
        const { parentNode } = btn;

        const lockStatus = parentNode.querySelector('input[type="radio"]:checked').value;
        const hiddenInput = parentNode.querySelector('div');

        if (lockStatus === 'unlock') {
            const btnContent = btn.textContent;

            if (btnContent === 'Show more') {
                hiddenInput.style.display = 'block';
                btn.textContent = 'Hide it';
            }
            else if (btnContent === 'Hide it') {
                hiddenInput.style.display = 'none';
                btn.textContent = 'Show more';
            }
        }
    }));
}