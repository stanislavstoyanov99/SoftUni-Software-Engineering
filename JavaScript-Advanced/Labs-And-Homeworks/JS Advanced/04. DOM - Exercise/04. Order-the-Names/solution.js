function solve() {
    const addButton = document.querySelector('#exercise button');

    addButton.addEventListener('click', onClick);

    const list = {};

    // Fulfill list with uppercase letters
    const items = document.querySelector('ol').querySelectorAll('li');

    for (const item of [...items]) {
        if (item.textContent.trim().length == 0) {
            continue;
        }

        const letter = item.textContent[0].toUpperCase();
        list[letter] = item.textContent;
    }

    function onClick() {
        const inputField = document.querySelector('#exercise input');
        const value = inputField.value;
        
        const firstLetter = value[0].toUpperCase();
        const name = firstLetter + value.slice(1).toLowerCase();
        
        // Check if person name is already in the list
        if (list.hasOwnProperty(firstLetter) == false) {
            list[firstLetter] = name;
        } else {
            list[firstLetter] = list[firstLetter] + ', ' + name;
        }

        // DOM Manipulations
        const index = firstLetter.charCodeAt(0) - 65;
        items[index].textContent = list[firstLetter];

        inputField.value = '';
    }
}