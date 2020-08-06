import { getAllRecipes } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        recipe: await this.load('./templates/home/recipe.hbs'),
        notFound: await this.load('./templates/home/notFound.hbs')
    };

    let data = {};
    Object.assign(data, this.app.userData);

    if (this.app.userData.username) {
        try {
            notifications.showLoader();

            data.recipes = await getAllRecipes();
            if (data.recipes.code) {
                throw data.recipes;
            }

            notifications.hideLoader();
        } catch (error) {
            notifications.hideLoader();
            notifications.showNotification(error.message, 'error');
        }
    }

    notifications.hideLoader();
    this.partial('./templates/home/home.hbs', data);
}