function solve() {
   const textArea = document.querySelector('.chat-box-footer #chat_input');
   const sendButton = document.querySelector('.chat-box-footer #send');
   const messages = document.getElementById('chat_messages');

   sendButton.addEventListener('click', () => {
      const currMessage = document.createElement('div');
      currMessage.setAttribute('class', 'message my-message');
      currMessage.textContent = textArea.value;

      messages.appendChild(currMessage);
      textArea.value = '';
   });
}