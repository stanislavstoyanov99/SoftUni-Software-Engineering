import API from './api.js';

const appId = 'C5C9CE57-7783-37DF-FF53-64C9CED40E00';
const restApiKey = '76C26AF1-986B-4E3D-AA80-325F2EE86C0F';

const endpoints = {
    ARTICLES: 'data/articles'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreateArticle(article) {
    return api.post(endpoints.ARTICLES, article);
}

export async function getArticleById(id) {
    return api.get(endpoints.ARTICLES + '/' + id);
}

export async function getArticleByCategory(category) {
    const url = endpoints.ARTICLES + `?where=category%3D%27${escape(category)}%27`;
    return api.get(url);
}

export async function getArticleByUserId(userId) {
    const url = endpoints.ARTICLES + `?where=ownerId%3D%27${userId}%27`;
    return api.get(url);
}

export async function apiEditArticle(editedArticle, id) {
    return api.put(endpoints.ARTICLES + '/' + id, editedArticle);
}

export async function apiDeleteArticle(id) {
    return api.delete(endpoints.ARTICLES + '/' + id);
}

export async function getAllArticles() {
    return api.get(endpoints.ARTICLES);
}