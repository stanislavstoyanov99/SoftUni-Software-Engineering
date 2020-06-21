function addItem() {
    const inputField = document.getElementById('newItemText');
    const items = document.getElementById('items');

    if (inputField.value === '') { 
        return; 
    }

    const li = document.createElement('li');
    li.textContent = inputField.value;
    items.appendChild(li);

    inputField.value = '';
}