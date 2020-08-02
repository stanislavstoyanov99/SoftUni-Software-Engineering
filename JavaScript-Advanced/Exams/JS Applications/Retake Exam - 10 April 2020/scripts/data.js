import API from './api.js';

const appId = '867173B5-D687-667A-FF2A-6D3BFFC73600';
const restApiKey = '8FAC17A7-E639-4C47-B48B-6419D3A04C73';

const endpoints = {
    POSTS: 'data/posts'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreatePost(post) {
    return api.post(endpoints.POSTS, post);
}

export async function getPostById(id) {
    return api.get(endpoints.POSTS + '/' + id);
}

export async function apiEditPost(editedPost, id) {
    return api.put(endpoints.POSTS + '/' + id, editedPost);
}

export async function apiDeletePost(id) {
    return api.delete(endpoints.POSTS + '/' + id);
}

export async function getAllPosts() {
    return api.get(endpoints.POSTS);
}