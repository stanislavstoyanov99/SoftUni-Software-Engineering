import * as data from '../api/data.js';

export default async function () {
    let furniture = [];

    try {
        furniture = await data.getAllFurniture();
    } catch (error) {
        alert(`Error: ${error.message}`);
        console.error(error);
        return;
    }

    const context = { furniture };
    await this.partial('./templates/allFurniture.hbs', context);
}