function addItem() {
    const inputField = document.getElementById('newText');
    const items = document.getElementById('items');

    const inputValue = inputField.value;
    if (inputValue === '') { 
        return; 
    }

    const li = document.createElement('li');
    const liText = document.createTextNode(inputField.value);
    
    const deleteLink = document.createElement('a');
    deleteLink.href = '#';
    deleteLink.textContent = '[Delete]';

    li.appendChild(liText);
    li.appendChild(deleteLink);

    deleteLink.addEventListener('click', (e) => {
        e.preventDefault();
        e.target.parentElement.remove();
    });
    
    items.appendChild(li);
    inputField.value = '';
}