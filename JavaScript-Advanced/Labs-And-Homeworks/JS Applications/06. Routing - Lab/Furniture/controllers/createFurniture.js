import * as data from '../api/data.js';

export default async function () {
    await this.partial('./templates/createFurniture.hbs');

    const form = document.querySelector('form');

    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        e.stopPropagation();

        const inputFields = [...form.querySelectorAll('input.form-control')];
        const errors = validateInputs(inputFields);
        const hasErrors = errors.length > 0 ? true : false;

        if (!hasErrors) {
            const furniture = {
                make: inputFields.find(i => i.id === 'make').value.trim(),
                model: inputFields.find(i => i.id === 'model').value.trim(),
                year: Number(inputFields.find(i => i.id === 'year').value.trim()),
                description: inputFields.find(i => i.id === 'description').value.trim(),
                price: inputFields.find(i => i.id === 'price').value.trim(),
                image: inputFields.find(i => i.id === 'image').value.trim(),
                material: inputFields.find(i => i.id === 'material').value.trim(),
            };

            try {
                await data.createFurniture(furniture);
                this.redirect('#/furniture/all');
            } catch (error) {
                alert(`Error: ${error.message}`);
                console.error(error);
                return;
            }
        } else {
            alert(errors.join('\n'));
        }
    });
}

function validateInputs(inputs) {
    const errors = [];

    const invalidInputMessage = 'This input value is invalid';
    const validInputMessage = 'This input value is valid';
    
    for (const input of inputs) {
        if (input.id === 'material') {
            continue;
        }

        const inputName = input.parentElement.querySelector('label').textContent;
        let isValid = true;

        if ((input.id === 'make' || input.id === 'model') && input.value.length < 4) {
            errors.push(`${inputName} is required and should be more than 3 symbols!`);
            isValid = false;
        } else if (input.id === 'year' && (Number(input.value) < 1950 || Number(input.value) > 2050)) {
            errors.push(`${inputName} is required and should be between 1950 and 2050!`);
            isValid = false;
        } else if (input.id === 'description' && input.value.length < 11) {
            errors.push(`${inputName} is required and should be more than 10 symbols!`);
            isValid = false;
        } else if (input.id === 'image' && input.value === '') {
            errors.push(`${inputName} is required!`);
            isValid = false;
        } else if (input.id === 'price' && Number(price.value) <= 0) {
            errors.push(`${inputName} is required and should be positive number!`);
            isValid = false;
        }

        if (isValid) {
            input.classList.add('is-valid');
            input.classList.remove('is-invalid');
            input.parentElement.querySelector('div.form-control-feedback').textContent = validInputMessage;
        } else {
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            input.parentElement.querySelector('div.form-control-feedback').textContent = invalidInputMessage;
        }
    }

    return errors;
}