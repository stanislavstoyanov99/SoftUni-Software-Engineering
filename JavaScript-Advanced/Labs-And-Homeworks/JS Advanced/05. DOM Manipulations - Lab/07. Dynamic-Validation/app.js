function validate() {
    const inputField = document.getElementById('email');

    inputField.addEventListener('change', function() {
        const inputValue = inputField.value;
        inputField.classList.remove('error');
        
        if (inputValue.match(/^[a-z-\.\d]+@[a-z-\.]+\.[a-z]{2,4}/)) { 
            return;
        }

        inputField.classList.add('error');
    })
}