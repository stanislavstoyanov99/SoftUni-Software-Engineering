function solve() {
    const addButton = document.querySelector('#container').lastElementChild;
    const inputName = document.querySelector('#container').firstElementChild;
    
    const inputAge = inputName.nextElementSibling;
    const inputKind = inputAge.nextElementSibling;
    const inputOwner = inputKind.nextElementSibling;

    addButton.addEventListener('click', (e) => {
        if (!inputName.value || !inputAge.value || !inputKind.value || !inputOwner.value) {
            return;
        }

        const adoptionSection = document.getElementById('adoption');
        const petList = adoptionSection.lastElementChild;

        const li = document.createElement('li');
        const liParagraph = document.createElement('p');
        const liName = document.createElement('strong');
        const liAge = document.createElement('strong');
        const liKind = document.createElement('strong');
        const liOwner = document.createElement('span');
        const contactBtn = document.createElement('button');

        liName.textContent = inputName.value;

        liAge.textContent = inputAge.value;

        liKind.textContent = inputKind.value;

        const textNameNode = document.createTextNode(' is a ');
        liParagraph.appendChild(liName);
        liParagraph.appendChild(textNameNode);

        const textAgeNode = document.createTextNode(' year old ');
        liParagraph.appendChild(liAge);
        liParagraph.appendChild(textAgeNode);

        liParagraph.appendChild(liKind);

        li.appendChild(liParagraph);

        liOwner.textContent = 'Owner: ' + inputOwner.value;
        li.appendChild(liOwner);

        contactBtn.textContent = 'Contact with owner';
        li.appendChild(contactBtn);

        petList.appendChild(li);

        contactBtn.addEventListener('click', onContactBtnClick);

        inputName.value = '';
        inputAge.value = '';
        inputKind.value = '';
        inputOwner.value = '';

        e.preventDefault();
    });

    function onContactBtnClick(e) {
        const parent = e.target.parentElement;
        e.target.remove();

        const newDiv = document.createElement('div');
        const newBtn = document.createElement('button');
        newBtn.textContent = 'Yes! I take it!';

        const input = document.createElement('input');
        input.setAttribute('placeholder', 'Enter your names');

        newDiv.appendChild(input);
        newDiv.appendChild(newBtn);

        parent.appendChild(newDiv);

        newBtn.addEventListener('click', onITakeItBtnClick);
    }

    function onITakeItBtnClick(e) {
        const newOwnerName = e.target.previousElementSibling.value;

        if (newOwnerName) {
            const adoptedSection = document.getElementById('adopted');
            const ulList = adoptedSection.lastElementChild;

            const currentListItem = e.target.parentElement.parentElement;
            currentListItem.lastElementChild.remove();

            const checkedBtn = document.createElement('button');
            checkedBtn.textContent = 'Checked';

            currentListItem.appendChild(checkedBtn);

            currentListItem.lastElementChild.previousElementSibling.textContent = 'New Owner: ' + newOwnerName;
            ulList.appendChild(currentListItem);

            checkedBtn.addEventListener('click', onCheckBtnClick);
        }
    }

    function onCheckBtnClick(e) {
        e.target.parentElement.remove();
    }
}

