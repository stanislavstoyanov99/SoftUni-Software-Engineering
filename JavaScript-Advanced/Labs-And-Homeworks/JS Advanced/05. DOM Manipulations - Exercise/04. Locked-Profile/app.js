function lockedProfile() {
    document.querySelector('#main').addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.nodeName === 'BUTTON') {
            const btn = e.target;
            const { parentNode } = btn;
    
            const lockStatus = parentNode.querySelector('input[type="radio"][value="lock"]');
            const hiddenInput = [...parentNode.querySelectorAll('div')].filter(d => d.id.includes('HiddenFields'))[0];

            if (!lockStatus.checked) {
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
        }
    }
}