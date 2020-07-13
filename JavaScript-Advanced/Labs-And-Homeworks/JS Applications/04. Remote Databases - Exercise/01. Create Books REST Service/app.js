(function attachEvents() {
    const elements = {
        loadBooks() { return document.getElementById('loadBooks') },
        submitBook() { return document.querySelector('form > button') },
        getBookTitle() { return document.getElementById('title') },
        getBookAuthor() { return document.getElementById('author') },
        getBookISBN() { return document.getElementById('isbn') },
        getTableBody() { return document.querySelector('table > tbody') },
        getForm() { return document.querySelector('form') }
    };

    elements.submitBook().addEventListener('click', onSubmitBtnClick);
    elements.loadBooks().addEventListener('click', loadBooks);
    elements.getTableBody().innerHTML = '';

    const baseUrl = 'https://softunihomework-f0671.firebaseio.com/';

    async function onSubmitBtnClick(e) {
        e.preventDefault();

        const title = elements.getBookTitle().value;
        const author = elements.getBookAuthor().value;
        const isbn = elements.getBookISBN().value;

        if(!title || !author || !isbn) {
            alert(`Invalid data.`);
            return;
        }

        const form = e.target.parentElement;
        if (form.getAttribute('edit-id')) {
            await edit(e);
        } else {
            const book = { title, author, isbn };

            await fetch(baseUrl + 'Books.json', {
                method: 'POST',
                body: JSON.stringify(book)
            })
                .then(() => loadBooks(e))
                .catch(error => alert(error));
        }

        elements.getBookTitle().value = '';
        elements.getBookAuthor().value = '';
        elements.getBookISBN().value = '';
    }

    async function edit(e) {   
        const bookToUpdate = { 
            title: elements.getBookTitle().value,
            author: elements.getBookAuthor().value,
            isbn: elements.getBookISBN().value
        };

        const form = e.target.parentElement;
        const bookId = form.getAttribute('edit-id');
        const url = baseUrl + `Books/${bookId}.json`;

        await fetch(url, {
            method: 'PUT',
            body: JSON.stringify(bookToUpdate)
        })
            .then(() => loadBooks(e))
            .catch(error => alert(error));
            
        form.removeAttribute('edit-id');
    }

    async function loadBooks(e) {
        e.preventDefault();

        try {
            const response = await fetch(baseUrl + 'Books.json');
            const books = await response.json();
            
            if(!books) {
                alert('There are not any books in the database.');
                return;
            }

            renderBooks(books);
        } catch (error) {
            alert(`Error: ${error.message}`);       
        }
    }

    function renderBooks(books) {
        elements.getTableBody().innerHTML = '';

        Object.entries(books).forEach(([id, {title, author, isbn}]) => {
            const tr = document.createElement('tr');
            tr.setAttribute('data-id', id);
            tr.innerHTML +=
             `<tr>
              <td>${title}</td>
              <td>${author}</td>
              <td>${isbn}</td>`;
            
            const tdElement = document.createElement('td');
        
            const editBtn = document.createElement('button');
            editBtn.textContent = 'Edit';
            editBtn.addEventListener('click', onEditBtnClick);

            const deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';
            deleteBtn.addEventListener('click', onDeleteBtnClick);
            
            tdElement.append(editBtn, deleteBtn);
            elements.getTableBody().appendChild(tr);
            elements.getTableBody().lastElementChild.appendChild(tdElement);
        });
    }

    function getCurrentBookId(e) {
        const currTr = e.target.parentElement.parentElement;
        const bookId = currTr.getAttribute('data-id');
        return bookId;
    }

    async function onEditBtnClick(e) {
        e.preventDefault();

        const bookId = getCurrentBookId(e);
        elements.getForm().setAttribute('edit-id', bookId);

        const currBookTitle = e.target.parentElement.parentElement.firstElementChild;
        const currBookAuthor = currBookTitle.nextElementSibling;
        const currBookIsbn = currBookAuthor.nextElementSibling;
        
        elements.getBookTitle().value = currBookTitle.textContent;
        elements.getBookAuthor().value = currBookAuthor.textContent;
        elements.getBookISBN().value = currBookIsbn.textContent;
    }

    async function onDeleteBtnClick(e) {
        const bookId = getCurrentBookId(e);
        const url = baseUrl + `Books/${bookId}.json`;
        
        await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-type': 'application/json'
            }
        })
            .then(() => loadBooks(e))
            .catch(error => alert(error));
    }
})();