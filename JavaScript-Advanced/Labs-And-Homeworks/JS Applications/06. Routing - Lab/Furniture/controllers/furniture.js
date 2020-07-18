import * as data from '../api/data.js';

export async function furnitureDetails() {
    const furnitureId = this.params.id;
    const currFurniture = await data.getFurnitureById(furnitureId);

    this.partial('./templates/furnitureDetails.hbs', currFurniture);
}

export async function deleteFurniture() {
    const furnitureId = this.params.id;
    await data.deleteFurniture(furnitureId);
    this.redirect('#/furniture/mine');
}