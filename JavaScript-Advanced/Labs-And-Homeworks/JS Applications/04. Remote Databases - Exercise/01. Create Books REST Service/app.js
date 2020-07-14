import * as data from './data.js';
import createElement from './dom.js';

window.addEventListener('load', () => {
    const elements = {
        loadBooksBtn() { return document.getElementById('loadBooks') },
        submitBookBtn() { return document.querySelector('form > button') },
        getBookTitle() { return document.getElementById('title') },
        getBookAuthor() { return document.getElementById('author') },
        getBookISBN() { return document.getElementById('isbn') },
        getTableBody() { return document.querySelector('table > tbody') },
        getForm() { return document.querySelector('form') }
    };

    elements.getTableBody().innerHTML = '';

    elements.submitBookBtn().addEventListener('click', onSubmitBtnClick);
    elements.loadBooksBtn().addEventListener('click', loadBooks);

    async function onSubmitBtnClick(e) {
        e.preventDefault();

        const title = elements.getBookTitle().value;
        const author = elements.getBookAuthor().value;
        const isbn = elements.getBookISBN().value;

        if (!title || !author || !isbn) {
            alert(`Invalid data.`);
            return;
        }

        const form = e.target.parentElement;
        elements.submitBookBtn().disabled = true;
        elements.submitBookBtn().textContent = 'Please wait...';

        if (form.getAttribute('edit-id')) {
            await edit(e);
        } else {
            const book = { title, author, isbn };

            try {
                await data.createBook(book);
                loadBooks(e);
                clearInput();
            } catch (error) {
                handleError(error);
                return;
            }
        }

        elements.submitBookBtn().disabled = false;
        elements.submitBookBtn().textContent = 'Submit';
    }

    async function edit(e) {
        const bookToUpdate = {
            title: elements.getBookTitle().value,
            author: elements.getBookAuthor().value,
            isbn: elements.getBookISBN().value
        };

        const form = e.target.parentElement;
        const bookId = form.getAttribute('edit-id');

        try {
            await data.editBook(bookId, bookToUpdate);
            clearInput();
            loadBooks(e);
        } catch (error) {
            handleError(error);
            return;
        }

        form.removeAttribute('edit-id');
    }

    async function loadBooks(e) {
        e.preventDefault();

        elements.getTableBody().innerHTML = '<tr><td colspan="5">Loading...</td><tr>';
        elements.loadBooksBtn().disabled = true;

        try {
            const books = await data.getBooks();

            if (!books) {
                alert('There are not any books in the database.');
                return;
            }

            elements.getTableBody().innerHTML = '';
            elements.loadBooksBtn().disabled = false;

            renderBooks(books);
        } catch (error) {
            handleError(error);
            return;
        }
    }

    function renderBooks(books) {
        Object.entries(books).forEach(([id, { title, author, isbn }]) => {
            const editBtn = createElement('button', 'Edit', {
                id: `editBtn-${id}`
            });
            editBtn.addEventListener('click', onEditBtnClick);

            const deleteBtn = createElement('button', 'Delete', {
                id: `deleteBtn-${id}`
            });
            deleteBtn.addEventListener('click', onDeleteBtnClick);

            const bookElemenet = createElement('tr', [
                createElement('td', title),
                createElement('td', author),
                createElement('td', isbn),
                createElement('td', [
                    editBtn,
                    deleteBtn
                ])
            ]);

            bookElemenet.setAttribute('data-id', id);

            elements.getTableBody().appendChild(bookElemenet);
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
        const deleteBtn = document.querySelector(`#deleteBtn-${bookId}`);

        try {
            deleteBtn.disabled = true;
            deleteBtn.textContent = 'Please wait...';
            
            await data.deleteBook(bookId);
            await loadBooks(e);
        } catch (error) {
            handleError(error);
            return;
        } finally {
            deleteBtn.disabled = false;
            deleteBtn.textContent = 'Delete';
        }
    }

    function handleError(error) {
        alert(`Error: ${error.message}`);
    }

    function clearInput() {
        elements.getBookTitle().value = '';
        elements.getBookAuthor().value = '';
        elements.getBookISBN().value = '';
    }
});