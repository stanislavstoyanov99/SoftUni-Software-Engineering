function attachEvents() {
    const elements = {
        person() { return document.getElementById('person') },
        phone() { return document.getElementById('phone') },
        createButton() { return document.getElementById('btnCreate') },
        loadButton() { return document.getElementById('btnLoad') },
        phoneBook() { return document.getElementById('phonebook') }
    };

    const url = 'https://phonebook-nakov.firebaseio.com/phonebook.json';

    elements.createButton().addEventListener('click', createContact);

    elements.loadButton().addEventListener('click', reloadContacts);

    function createContact() {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();
        const contact = { person, phone };

        if (!person || !phone) {
            handleError();
            return;
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(contact)
        })
            .then((respone) => respone.json())
            .then(() => reloadContacts())
            .catch((error) => handleError(error));

        elements.person().value = '';
        elements.phone().value = '';
    }

    function reloadContacts() {
        elements.phoneBook().innerHTML = '';

        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                if (!data) {
                    alert('There are not any contacts.');
                    return;
                }

                const contactIds = Array.from(Object.keys(data));

                contactIds.forEach(id => {
                    const listItem = document.createElement('li');
                    const name = data[id].person;
                    const phone = data[id].phone;

                    listItem.textContent = `${name}:${phone}`;

                    const deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';
                    listItem.appendChild(deleteBtn);

                    elements.phoneBook().appendChild(listItem);

                    deleteBtn.addEventListener('click', () => deleteContact(id));
                })
            });
    }

    function deleteContact(id) {
        const url = `https://phonebook-nakov.firebaseio.com/phonebook/${id}.json`;

        fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-type': 'application/json'
            }
        })
            .then(() => reloadContacts())
            .catch((error) => handleError(error));
    }

    function handleError(error) {
        elements.person().value = '';
        elements.phone().value = '';
        alert('Error');
    }
}

attachEvents();