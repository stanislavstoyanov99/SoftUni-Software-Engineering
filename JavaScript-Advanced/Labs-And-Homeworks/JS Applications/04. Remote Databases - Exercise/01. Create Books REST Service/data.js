function host(endpoint) {
    return `https://softunihomework-f0671.firebaseio.com/${endpoint}.json`;
}

const api = {
    books: 'Books',
    editBook: 'Books/',
    deleteBook: 'Books/'
};

export async function getBooks() {
    const response = await fetch(host(api.books));
    const books = await response.json();

    return books;
}

export async function createBook(book) {
    const createdBook = await fetch(host(api.books), {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(book)
    });

    return createdBook;
}

export async function editBook(id, book) {
    const response = await fetch(host(`${api.editBook + id}`), {
        method: 'PUT',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(book)
    });

    const editedBook = await response.json();

    return editedBook;
}

export async function deleteBook(id) {
    return await fetch(host(`/${api.deleteBook + id}`), {
        method: 'DELETE'
    });
}