const firebaseConfig = {
    apiKey: "AIzaSyCj40Y6W4e-SqNr9Onp_3JfgBaXM0tYMSw",
    authDomain: "testapp-bb3a7.firebaseapp.com",
    databaseURL: "https://testapp-bb3a7.firebaseio.com",
    projectId: "testapp-bb3a7",
    storageBucket: "testapp-bb3a7.appspot.com",
    messagingSenderId: "946952065384",
    appId: "1:946952065384:web:4f196d78478eb7d42346dd",
    measurementId: "G-DBLZEGG97L"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

export async function getBook(id) {
    const url = `https://testapp-bb3a7.firebaseio.com/Books/${id}.json`;
    const response = await fetch(url);
    const book = await response.json();

    console.log(book);
}

export async function getBooks() {
    const url = `https://testapp-bb3a7.firebaseio.com/Books.json`;
    const response = await fetch(url);

    return await response.json();
}

export async function createBook(title, author) {
    const url = `https://testapp-bb3a7.firebaseio.com/Books.json`;
    const newBook = { title, author };

    return await fetch(url, {
        method: 'POST',
        body: JSON.stringify(newBook)
    });
}

export async function patchBook(title, author) {
    const url = `https://testapp-bb3a7.firebaseio.com/Books.json`;
    const patchedBook = { title, author };

    return await fetch(url, {
        method: 'PATCH',
        body: JSON.stringify(patchedBook)
    });
}

export async function updateBookTitle(newTitle) {
    const url = `https://testapp-bb3a7.firebaseio.com/Books/1/title.json`;

    return await fetch(url, {
        method: 'PUT',
        body: JSON.stringify(newTitle)
    });
}

export async function createUser(email, password) {
    const result = await firebase.auth().createUserWithEmailAndPassword(email, password)
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;

            console.log(`Firebase error: ${errorCode} (${errorMessage})`);
        });

    console.log(result);
}

export async function signInUser(email, password) {
    const result = await firebase.auth().signInWithEmailAndPassword(email, password)
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            console.log(`Firebase error: ${errorCode} (${errorMessage})`);
        });

    console.log(result);
}

export async function signOutUser() {
    await firebase.auth().signOut()
        .then(() => {
            console.log('Sign-out successfull');
        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            console.log(`Firebase error: ${errorCode} (${errorMessage})`);
        });
}
