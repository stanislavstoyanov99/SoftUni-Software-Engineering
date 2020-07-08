async function loadCommits() {
    const elements = {
        getUsername() { return document.getElementById('username') },
        getRepo() { return document.getElementById('repo') },
        commits() { return document.getElementById('commits') }
    };

    const username = elements.getUsername().value;
    const repo = elements.getRepo().value;

    elements.commits().innerHTML = '';
    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    const response = await fetch(url);

    try {
        if (response.status >= 400) {
            throw response;
        }

        const data = await response.json();
        loadData(data);

    } catch (error) {
        handleError(error);
    }

    function loadData(data) {
        data.forEach(item => {
            const listItem = document.createElement('li');
            listItem.textContent = `${item.commit.author.name}: ${item.commit.message}`;

            elements.commits().appendChild(listItem);
            clearInput();
        });
    }

    function handleError(error) {
        const errorMessage = `Error: ${error.status} (${error.statusText})`;
        const listItem = document.createElement('li');
        listItem.textContent = errorMessage;

        elements.commits().appendChild(listItem);
        clearInput();
    }

    function clearInput() {
        elements.getUsername().value = '';
        elements.getRepo().value = '';
    }
}