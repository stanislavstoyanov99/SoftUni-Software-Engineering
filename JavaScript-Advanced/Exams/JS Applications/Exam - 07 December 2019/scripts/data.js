import API from './api.js';

const appId = '9B05ABF2-850D-2A30-FF42-7C8CC938CA00';
const restApiKey = '762E544E-A957-4500-8734-9AECCA8EBF95';

const endpoints = {
    TREKS: 'data/treks'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreateTrek(trek) {
    return api.post(endpoints.TREKS, trek);
}

export async function apiEditTrek(editedTrek, id) {
    return api.put(endpoints.TREKS + '/' + id, editedTrek);
}

export async function apiDeleteTrek(id) {
    return api.delete(endpoints.TREKS + '/' + id);
}

export async function getTrekById(id) {
    return api.get(endpoints.TREKS + '/' + id);
}

export async function getAllTreks() {
    return api.get(endpoints.TREKS);
}

export async function getTreksByUserId(userId) {
    const url = endpoints.TREKS + `?where=ownerId%3D%27${userId}%27`;
    return api.get(url);
}

export async function likeTrek(trek, id) {
    trek.likes++;

    return await apiEditTrek(trek, id);
}