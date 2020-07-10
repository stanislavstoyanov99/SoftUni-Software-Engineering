import * as data from './data.js';
import createElement from './dom.js';

window.addEventListener('load', () => {
    const elements = {
        addButton() { return document.querySelector('#addForm > .add') },
        loadButton() { return document.querySelector('button.load') },
        updateButton() { return document.querySelector('button.update') },
        deleteButton() { return document.querySelector('button.delete') },
        anglerField() { return document.querySelector('#addForm > .angler') },
        weightField() { return document.querySelector('#addForm > .weight') },
        speciesField() { return document.querySelector('#addForm > .species') },
        locationField() { return document.querySelector('#addForm > .location') },
        baitField() { return document.querySelector('#addForm > .bait') },
        captureTimeField() { return document.querySelector('#addForm > .captureTime') },
        catches() { return document.getElementById('catches') }
    };

    elements.addButton().addEventListener('click', onAddBtnClick);
    elements.loadButton().addEventListener('click', loadCatches);

    async function onAddBtnClick(e) {
        e.preventDefault();

        const inputAngler = elements.anglerField().value;
        const inputWeight = elements.weightField().value;
        const inputSpecies = elements.speciesField().value;
        const inputLocation = elements.locationField().value;
        const inputBait = elements.baitField().value;
        const inputCaptureTime = elements.captureTimeField().value;

        const catchObj = {
            angler: inputAngler,
            weight: inputWeight,
            species: inputSpecies,
            location: inputLocation,
            bait: inputBait,
            captureTime: inputCaptureTime
        };

        try {
            await data.createCatch(catchObj);
        } catch (error) {
            alert(`Error: ${error}`);
            clearInput();
            return;
        }

        await loadCatches();
        clearInput();
    }

    async function loadCatches() {
        elements.catches().innerHTML = '';
        let catches = {};

        try {
            catches = await data.getCatches();
        } catch (error) {
            alert(`Error: ${error}`);
            return;
        }

        if (catches) {
            Object.entries(catches).forEach(([id, value]) => {
                const catchElement = createCatchElement(id, value);
                elements.catches().appendChild(catchElement);
            });
        } else {
            elements.catches.innerHTML = 'There are not any catches.';
        }
    }

    function createCatchElement(id, catchObj) {
        const { angler, weight, species, location, bait, captureTime } = catchObj;

        const divContainer = document.createElement('div');
        divContainer.setAttribute('class', 'catch');
        divContainer.setAttribute('data-id', id);

        divContainer.innerHTML =
            `<label>Angler</label>
            <input type="text" class="angler" value="${angler}"/>
            <hr>
            <label>Weight</label>
            <input type="number" class="weight" value="${weight}"/>
            <hr>
            <label>Species</label>
            <input type="text" class="species" value="${species}"/>
            <hr>
            <label>Location</label>
            <input type="text" class="location" value="${location}"/>
            <hr>
            <label>Bait</label>
            <input type="text" class="bait" value="${bait}"/>
            <hr>
            <label>Capture Time</label>
            <input type="number" class="captureTime" value="${captureTime}"/>
            <hr>`;
        
        const updateButton = createElement('button', 'Update', {
            className: 'update'
        });
        const deleteButton = createElement('button', 'Delete', {
            className: 'delete'
        });

        updateButton.addEventListener('click', onUpdateBtnClick);
        deleteButton.addEventListener('click', onDeleteBtnClick);

        divContainer.append(updateButton, deleteButton);

        return divContainer;
    }

    // TODO
    function onUpdateBtnClick(e) {
        e.preventDefault();
    }

    // TODO
    function onDeleteBtnClick(e) {
        e.preventDefault();
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