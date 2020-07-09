function attachEvents() {
    const elements = {
        loadPostsButton() { return document.getElementById('btnLoadPosts') },
        viewPostButton() { return document.getElementById('btnViewPost') },
        getPostsList() { return document.getElementById('posts') },
        postTitle() { return document.getElementById('post-title') },
        postBody() { return document.getElementById('post-body') },
        postComments() { return document.getElementById('post-comments') }
    }

    const url = 'https://blog-apps-c12bf.firebaseio.com/';

    elements.loadPostsButton().addEventListener('click', loadPosts);
    elements.viewPostButton().addEventListener('click', viewPosts);

    function loadPosts() {
        elements.getPostsList().innerHTML = `<option disabled checked>Choose a post</option>`;

        fetch(url + 'posts.json')
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                }

                return response.json();
            })
            .then(data => {
                const posts = Object.entries(data);

                posts.forEach(([postId, {title}]) => {
                    const optionItem = document.createElement('option');

                    optionItem.value = postId;
                    optionItem.textContent = title;
            
                    elements.getPostsList().appendChild(optionItem);
                });              
            })
            .catch(error => handleError(error));
    }

    function viewPosts() {
        const posts = elements.getPostsList();
        const postId = posts.options[posts.selectedIndex].value;

        fetch(url + `posts/${postId}.json`)
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                }

                return response.json();
            })
            .then(data => {
                clearOutput();

                const { body, comments, title } = data;

                elements.postTitle().textContent = title;
                elements.postBody().textContent = body;

                if (!data.hasOwnProperty('comments')) {
                    elements.postComments().textContent = '';
                    return;
                }
                
                Object.entries(comments).forEach(([, {text}]) => {
                    const listItem = document.createElement('li');
                    listItem.textContent = text;

                    elements.postComments().appendChild(listItem);
                });
            })
            .catch(error => handleError(error));
    }

    function handleError(error) {
        alert(`Error: ${error.status} ${error.statusText}`);
    }

    function clearOutput() {
        elements.postTitle().textContent = '';
        elements.postBody().textContent = '';
        elements.postComments().innerHTML = '';
    }
}

attachEvents();