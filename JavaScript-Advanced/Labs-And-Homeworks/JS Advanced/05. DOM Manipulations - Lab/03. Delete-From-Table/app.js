function deleteByEmail() {
    const customers = [...document.querySelectorAll('#customers td:last-child')];
    const inputField = document.querySelector('input[name="email"]');
    const result = document.getElementById('result');

    const inputValue = inputField.value;
    if (inputValue === '') { return; }

    const email = customers.find(td => td.textContent === inputValue);

    if (!email) {
        result.textContent = 'Not found.';
        return;
    }

    inputField.value = '';
    email.parentElement.remove();
    result.textContent = 'Deleted.'
}