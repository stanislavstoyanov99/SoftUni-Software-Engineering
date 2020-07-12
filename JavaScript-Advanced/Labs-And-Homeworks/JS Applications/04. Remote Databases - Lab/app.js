import * as data from './data.js';

(async function() {
    const booksUl = document.getElementById('books-list');
    const books = await data.getBooks();

    Object.entries(books).forEach(([id, {author, title}]) => {
        const listItem = document.createElement('li');
        listItem.textContent = `Id: ${id} | Author: ${author} | Title: ${title}`;

        booksUl.appendChild(listItem);
    });
}());