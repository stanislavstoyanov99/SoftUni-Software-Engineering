function attachEvents() {
    const elements = {
        person() { return document.getElementById('person') },
        phone() { return document.getElementById('phone') },
        createButton() { return document.getElementById('btnCreate') },
        loadButton() { return document.getElementById('btnLoad') },
        phoneBook() { return document.getElementById('phonebook') }
    };

    const url = `http://localhost:3000/phonebook`;
    let contacts = [];

    elements.createButton().addEventListener('click', () => {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();

        fetch(url, {
            method: 'POST',
            body: JSON.stringify({ person, phone })
        })
            .then((respone) => respone.json())
            .then((createdContact) => {
                contacts.push(createdContact);
                elements.person().value = '';
                elements.phone().value = '';

                reloadContacts();
            });
    });

    elements.loadButton().addEventListener('click', () => {
        reloadContacts();
    });

    function reloadContacts() {
        elements.phoneBook().textContent = '';

        contacts.forEach(contact => {
            const listItem = document.createElement('li');
            const id = Object.keys(contact)[0];

            listItem.textContent = `${contact[id].person}:${contact[id].phone}`;

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            listItem.appendChild(deleteBtn);

            elements.phoneBook().appendChild(listItem);

            // Delete functionality only removes from DOM, cannot make it to remove the object from the array
            // It would be better if we have a database in order to make REST calls
            deleteBtn.addEventListener('click', (e) => {
                e.target.parentElement.remove();
            });
        });
    }
}

attachEvents();