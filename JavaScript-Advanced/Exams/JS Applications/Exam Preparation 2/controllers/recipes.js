import { apiCreateRecipe, apiDeleteRecipe, apiEditRecipe, getRecipeById, likeRecipe } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';
import validateErrors from '../scripts/validateErrors.js';

let CATEGORIES = {
    'Vegetables and legumes/beans': 'https://img.webmd.com/dtmcms/live/webmd/consumer_assets/site_images/article_thumbnails/slideshows/powerhouse_vegetables_slideshow/650x350_powerhouse_vegetables_slideshow.jpg',
    'Fruits': 'https://post.medicalnewstoday.com/wp-content/uploads/sites/3/2020/02/325253_2200-1200x628.jpg',
    'Grain Food': 'https://www.world-grain.com/ext/resources/images/g/r/a/i/n/d/e/d/d/d/07/GrainFoods_Embedded.jpg',
    'Milk, cheese, eggs and alternatives': 'https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/09/12/10/milkcheese1209a.jpg?w968',
    'Lean meats and poultry, fish and alternatives': 'https://cherifaaboulfettouh.com/media-library/drcherifa/Beef-And-Other-Meats_(1).jpg'
};

export async function createRecipeGet() {
    notifications.showLoader();

    const token = validateToken(this);

    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/recipes/create.hbs', this.app.userData);
    notifications.hideLoader();
}

export async function createRecipePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }
    
    const errors = validateErrors(this);
    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const recipe = {
        meal: this.params.meal,
        ingredients: this.params.ingredients.split(',').map(e => e.trim()),
        prepMethod: this.params.prepMethod,
        description: this.params.description,
        foodImageURL: this.params.foodImageURL,
        category: this.params.category,
        categoryImageURL: CATEGORIES[this.params.category]
    };

    try {
        notifications.showLoader();
        const createdRecipe = await apiCreateRecipe(recipe);

        if (createdRecipe.code) {
            throw createdRecipe;
        }

        notifications.hideLoader();
        notifications.showNotification('Recipe shared successfully!', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function editRecipeGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let recipe = {};

    try {
        notifications.showLoader();
        recipe = await getRecipeById(this.params.id);

        if (recipe.ownerId !== this.app.userData.userId) {
            notifications.showNotification('You cannot edit recipe, which is not shared by you.', 'error');
            notifications.hideLoader();
            return;
        }

        recipe.ingredients = recipe.ingredients.join(', ');

        if (recipe.code) {
            throw recipe;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    Object.assign(recipe, this.app.userData);

    await this.partial('./templates/recipes/edit.hbs', recipe);

    document.querySelectorAll('select[name=category]>option').forEach(o => {
        if (o.textContent == recipe.category) {
            o.selected = true;
        }
    });
}

export async function editRecipePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const errors = validateErrors(this);
    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const recipe = {
        meal: this.params.meal,
        ingredients: this.params.ingredients.split(',').map(e => e.trim()),
        prepMethod: this.params.prepMethod,
        description: this.params.description,
        foodImageURL: this.params.foodImageURL,
        category: this.params.category,
        categoryImageURL: CATEGORIES[this.params.category]
    };

    try {
        notifications.showLoader();
        const editedRecipe = await apiEditRecipe(recipe, this.params.id);

        if (editedRecipe.code) {
            throw editedRecipe;
        }

        notifications.hideLoader();
        notifications.showNotification('Recipe edited successfully!', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function deleteRecipeGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        notifications.showLoader();

        const recipe = await getRecipeById(this.params.id);
        if (recipe.ownerId !== this.app.userData.userId) {
            notifications.showNotification('You cannot archive recipe, which is not shared by you.', 'error');
            notifications.hideLoader();
            return;
        }
        
        const deletionTime = await apiDeleteRecipe(this.params.id);

        if (deletionTime.code) {
            throw deletionTime;
        }

        notifications.hideLoader();
        notifications.showNotification('Your recipe was archived.', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function likeRecipeGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let recipe = {};

    try {
        notifications.showLoader();

        recipe = await getRecipeById(this.params.id);

        if (recipe.code) {
            throw recipe;
        }

        if (recipe.ownerId === this.app.userData.userId) {
            throw new Error('You cannot like recipe shared by you.');
        }

        const likedRecipe = await likeRecipe(recipe, this.params.id);

        if (likedRecipe.code) {
            throw likedRecipe;
        }

        notifications.hideLoader();
        notifications.showNotification('You liked that recipe.', 'info');     
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function detailsGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let recipe = {};

    try {
        notifications.showLoader();
        recipe = await getRecipeById(this.params.id);

        if (recipe.code) {
            throw recipe;
        }

        if (recipe.ownerId === this.app.userData.userId) {
            recipe.isCreator = true;
        } else {
            recipe.isCreator = false;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    Object.assign(recipe, this.app.userData);

    this.partial('./templates/recipes/details.hbs', recipe);
}