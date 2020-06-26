function solve() {
    const addButton = document.getElementById('add');
    const taskInput = document.getElementById('task');
    const descriptionInput = document.getElementById('description');
    const dateInput = document.getElementById('date');

    addButton.addEventListener('click', (e) => {
        if (!taskInput.value && !descriptionInput.value && !dateInput.value) {
            return;
        }

        const openSection = document.querySelector('section').nextElementSibling;
        const openDiv = openSection.lastElementChild;

        const article = document.createElement('article');
        const heading = document.createElement('h3');
        const paragraphDescription = document.createElement('p');
        const dateParagraph = document.createElement('p');
        const divContainer = document.createElement('div');

        heading.textContent = taskInput.value;
        paragraphDescription.textContent = 'Description: ' + descriptionInput.value;
        dateParagraph.textContent = 'Due Date: ' + dateInput.value;

        divContainer.setAttribute('class', 'flex');
        const startBtn = document.createElement('button');
        const deleteBtn = document.createElement('button');

        startBtn.setAttribute('class', 'green');
        startBtn.textContent = 'Start';
        startBtn.addEventListener('click', onStartBtnClick);

        deleteBtn.setAttribute('class', 'red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', onDeleteBtnClick);

        divContainer.appendChild(startBtn);
        divContainer.appendChild(deleteBtn);

        article.appendChild(heading);
        article.appendChild(paragraphDescription);
        article.appendChild(dateParagraph);
        article.appendChild(divContainer);
        openDiv.appendChild(article);

        e.preventDefault();
    });

    function onStartBtnClick(e) {
        const inProgressDiv = document.getElementById('in-progress');

        let currArticle = e.target.parentElement.parentElement;
        e.target.parentElement.parentElement.remove();

        currArticle.lastElementChild.innerHTML = '';

        const deleteBtn = document.createElement('button');
        const finishBtn = document.createElement('button');

        deleteBtn.setAttribute('class', 'red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', onDeleteBtnClick);

        finishBtn.setAttribute('class', 'orange');
        finishBtn.textContent = 'Finish';
        finishBtn.addEventListener('click', onFinishBtnClick);

        currArticle.lastElementChild.appendChild(deleteBtn);
        currArticle.lastElementChild.appendChild(finishBtn);

        inProgressDiv.appendChild(currArticle);
    }

    function onDeleteBtnClick(e) {
        e.target.parentElement.parentElement.remove();
    }

    function onFinishBtnClick(e) {
        const completeSection = document.querySelector('section > div > .green').parentElement.parentElement;
        const completeDiv = completeSection.lastElementChild;
        
        let currArticle = e.target.parentElement.parentElement;
        e.target.parentElement.parentElement.remove();

        currArticle.lastElementChild.remove();

        completeDiv.appendChild(currArticle);
    }
}