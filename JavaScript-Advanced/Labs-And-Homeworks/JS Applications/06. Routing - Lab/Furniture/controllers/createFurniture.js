import * as data from '../api/data.js';

const invalidInputMessage = 'This input value is invalid';
const validInputMessage = 'This input value is valid';

export default async function() {
    await this.partial('./templates/createFurniture.hbs');

    const form = document.querySelector('form');

    form.addEventListener('submit', async (e) => {
        e.preventDefault();
        e.stopPropagation();

        // TODO - make validation and take data from form
        console.log(e.target);
    });
}