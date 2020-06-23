function encodeAndDecodeMessages() {
    const inputTextArea = document.querySelector("div > textarea:not(disabled)");
    const outputTextArea = document.querySelector("div > textarea[disabled]");

    const encodeBtn = inputTextArea.parentElement.querySelector("button");
    const decodeBtn = outputTextArea.parentElement.querySelector("button");

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    function encode() {
        encodedMessage = decryptor(inputTextArea.value, 'encode');

        outputTextArea.value = encodedMessage;

        inputTextArea.value = '';
    }

    function decode() {
        const decodedMessage = decryptor(outputTextArea.value, 'decode');

        outputTextArea.value = decodedMessage;
    }

    function decryptor(message, typeOfDecryption) {
        let resultMessage = '';

        for (let i = 0; i < message.length; i++) {
            const letter = message[i];

            let decryptedLetter = '';

            if (typeOfDecryption === 'encode') {
                decryptedLetter = letter.charCodeAt(0) + 1;
            } else if (typeOfDecryption === 'decode') {
                decryptedLetter = letter.charCodeAt(0) - 1;
            }

            resultMessage += String.fromCharCode(decryptedLetter);
        }

        return resultMessage;
    }
}