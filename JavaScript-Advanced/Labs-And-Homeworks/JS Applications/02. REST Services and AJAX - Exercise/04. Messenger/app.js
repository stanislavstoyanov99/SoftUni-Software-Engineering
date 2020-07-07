function attachEvents() {
    const elements = {
        name() { return document.getElementById('author') },
        inputMessage() { return document.getElementById('content') },
        sendButton() { return document.getElementById('submit') },
        refreshButton() { return document.getElementById('refresh') },
        messages() { return document.getElementById('messages') }
    };

    const url = 'https://rest-messanger.firebaseio.com/messanger.json';

    elements.sendButton().addEventListener('click', sendMessage);

    elements.refreshButton().addEventListener('click', loadMessages);

    function sendMessage() {
        const { value: author } = elements.name();
        const { value: content } = elements.inputMessage();
        const message = { author, content };

        if (!author || !content) {
            handleError();
            return;
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(message)
        })
            .then((respone) => respone.json())
            .then(() => loadMessages())
            .catch(() => handleError());

        elements.name().value = '';
        elements.inputMessage().value = '';
    }

    function loadMessages() {
        elements.messages().value = '';
        
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                const messagesIds = Array.from(Object.keys(data));
                
                const resultMessages = [];

                messagesIds.forEach(id => {
                    const authorName = data[id].author;
                    const authorMessage = data[id].content;
                    
                    resultMessages.push(`${authorName}: ${authorMessage}`);
                });

                elements.messages().value = resultMessages.join('\n');
            });
    }

    function handleError() {
        elements.inputMessage().value = '';
        elements.name().value = '';
        alert('Error');
    }
}

attachEvents();