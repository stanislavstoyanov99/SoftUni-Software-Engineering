import API from './api.js';

const appId = 'D0B1A2CE-A97A-3FDF-FF58-328454250800';
const restApiKey = 'A0667AFA-5773-4B1D-8B4F-92EA2DC95BE8';

const endpoints = {
    RECIPES: 'data/recipes'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreateRecipe(recipe) {
    return api.post(endpoints.RECIPES, recipe);
}

export async function apiEditRecipe(editedRecipe, id) {
    return api.put(endpoints.RECIPES + '/' + id, editedRecipe);
}

export async function apiDeleteRecipe(id) {
    return api.delete(endpoints.RECIPES + '/' + id);
}

export async function getRecipeById(id) {
    return api.get(endpoints.RECIPES + '/' + id);
}

export async function getAllRecipes() {
    return api.get(endpoints.RECIPES);
}

export async function likeRecipe(recipe, id) {
    recipe.likesCounter++;

    return await apiEditRecipe(recipe, id);
}