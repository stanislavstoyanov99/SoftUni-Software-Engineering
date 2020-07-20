import * as data from '../api/data.js';

export async function furnitureDetails() {
    const furnitureId = this.params.id;
    const currFurniture = await data.getFurnitureById(furnitureId);

    await this.partial('./templates/furnitureDetails.hbs', currFurniture);
}

export async function likeFurniture() {
    await data.likeFurniture(this.params.id, true);

    this.redirect('#/furniture/all');
}

export async function dislikeFurniture() {
    await data.likeFurniture(this.params.id, false);

    this.redirect('#/furniture/mine');
}