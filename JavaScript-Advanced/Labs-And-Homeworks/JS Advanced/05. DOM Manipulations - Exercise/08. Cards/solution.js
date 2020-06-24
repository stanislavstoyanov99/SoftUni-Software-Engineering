function solve() {
    const cards = document.querySelector('.cards');
    const resultDiv = document.getElementById('result');
    const historyDiv = document.getElementById('history');

    const leftSpan = resultDiv.firstElementChild;
    const rightSpan = resultDiv.lastElementChild;

    let firstCard;
    let secondCard;

    cards.addEventListener('click', (e) => {
        
        if (e.target.nodeName === 'IMG' && e.target.parentElement.id === 'player1Div') {
            e.target.src = 'images/whiteCard.jpg';
            leftSpan.textContent = e.target.name;
            firstCard = e.target;
        } else if (e.target.nodeName === 'IMG' && e.target.parentElement.id === 'player2Div') {
            e.target.src = 'images/whiteCard.jpg';
            rightSpan.textContent = e.target.name;
            secondCard = e.target;
        }

        if (leftSpan.textContent !== '' && rightSpan.textContent !== '') {
            const firstCardValue = Number(leftSpan.textContent);
            const secondCardValue = Number(rightSpan.textContent);

            if (firstCardValue > secondCardValue) {
                firstCard.style.border = '2px solid green';
                secondCard.style.border = '2px solid red';
            } else {
                secondCard.style.border = '2px solid green';
                firstCard.style.border = '2px solid red';
            }

            historyDiv.textContent += `[${leftSpan.textContent} vs ${rightSpan.textContent}] `;
            leftSpan.textContent = '';
            rightSpan.textContent = '';
        }
    });
}