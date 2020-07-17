import * as data from './data.js';

window.addEventListener('load', async () => {
    const elements = {
        addButton() { return document.querySelector('#addForm > .add') },
        loadButton() { return document.querySelector('button.load') },
        anglerField() { return document.querySelector('#addForm > .angler') },
        weightField() { return document.querySelector('#addForm > .weight') },
        speciesField() { return document.querySelector('#addForm > .species') },
        locationField() { return document.querySelector('#addForm > .location') },
        baitField() { return document.querySelector('#addForm > .bait') },
        captureTimeField() { return document.querySelector('#addForm > .captureTime') },
        mainFieldset() { return document.getElementById('main') },
        catches() { return document.getElementById('catches') }
    };

    // Load templates
    const catchCardTemplate = await (await fetch('./templates/catch-card.hbs')).text();

    const mainTemplate = await (await fetch('./templates/main-template.hbs')).text();

    Handlebars.registerPartial('catch-card', catchCardTemplate);
    const template = Handlebars.compile(mainTemplate);

    // Attach event listeners
    elements.addButton().addEventListener('click', onAddBtnClick);
    elements.loadButton().addEventListener('click', loadCatches);

    async function loadCatches() {
        try {
            const catches = await data.getCatches();
            const context = { catches };
            elements.mainFieldset().innerHTML = template(context);

            elements.catches().addEventListener('click', (e) => {
                const target = e.target;

                if (target.nodeName !== 'BUTTON') {
                    return;
                } else if (target.className === 'update') {
                    updateCatch(target.parentElement);
                } else if (target.className === 'delete') {
                    deleteCatch(target.parentElement);
                }
            });
        } catch (error) {
            alert(`Error: ${error}`);
            return;
        }
    }

    async function onAddBtnClick() {
        if (elements.anglerField().value === '' ||
            Number(elements.weightField().value) <= 0 ||
            elements.speciesField().value === '' ||
            elements.locationField().value === '' ||
            elements.baitField().value === '' ||
            Number(elements.captureTimeField().value) <= 0) {
            alert('Wrong data!');
            return;
        }

        const catchObj = {
            angler: elements.anglerField().value.trim(),
            weight: elements.weightField().value.trim(),
            species: elements.speciesField().value.trim(),
            location: elements.locationField().value.trim(),
            bait: elements.baitField().value.trim(),
            captureTime: elements.captureTimeField().value.trim()
        };

        try {
            await data.createCatch(catchObj);
            await loadCatches();
            clearInput();
        } catch (error) {
            alert(`Error: ${error}`);
            return;
        }
    }

    async function updateCatch(parentElement) {
        const id = parentElement.getAttribute('data-id');

        try {
            const angler = parentElement.querySelector('input.angler').value.trim();
            const weight = parentElement.querySelector('input.weight').value.trim();
            const species = parentElement.querySelector('input.species').value.trim();
            const location = parentElement.querySelector('input.location').value.trim();
            const bait = parentElement.querySelector('input.bait').value.trim();
            const captureTime = parentElement.querySelector('input.captureTime').value.trim();
    
            if (!angler ||
                Number(weight) <= 0 ||
                !species ||
                !location ||
                !bait ||
                Number(captureTime) <= 0) {
                alert('Invalid data.');
                return;
            }
    
            const updatedObj = { angler, weight, species, location, bait, captureTime };

            await data.updateCatch(id, updatedObj);
            console.info(`Element with id: ${id} has been updated.`);
        } catch (error) {
            alert(`Error: ${error}`);
            return;
        }
    }

    async function deleteCatch(parentElement) {
        const id = parentElement.getAttribute('data-id');

        try {
            await data.deleteCatch(id);
            parentElement.remove();
            console.info(`Element with id: ${id} has been deleted.`);
        } catch (error) {
            alert(`Error: ${error}`);
            return;
        }
    }

    function clearInput() {
        elements.anglerField().value = '';
        elements.weightField().value = '';
        elements.weightField().value = '';
        elements.speciesField().value = '';
        elements.locationField().value = '';
        elements.baitField().value = '';
        elements.captureTimeField().value = '';
    }
});