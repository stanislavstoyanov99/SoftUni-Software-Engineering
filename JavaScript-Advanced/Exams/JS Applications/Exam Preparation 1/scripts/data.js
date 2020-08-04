import API from './api.js';

const appId = 'B9FE87EA-10C1-3681-FF7D-3294CD7DE700';
const restApiKey = 'E01DEB21-2EB0-4A16-851F-8029DAF329A4';

const endpoints = {
    EVENTS: 'data/events'
};

const api = new API(appId, restApiKey, endpoints);

export const login = api.login.bind(api);
export const register = api.register.bind(api);
export const logout = api.logout.bind(api);

export async function apiCreateEvent(event) {
    return api.post(endpoints.EVENTS, event);
}

export async function apiEditEvent(editedEvent, id) {
    return api.put(endpoints.EVENTS + '/' + id, editedEvent);
}

export async function apiDeleteEvent(id) {
    return api.delete(endpoints.EVENTS + '/' + id);
}

export async function getEventById(id) {
    return api.get(endpoints.EVENTS + '/' + id);
}

export async function getAllEvents() {
    return api.get(endpoints.EVENTS);
}

export async function getEventsByUserId(userId) {
    const url = endpoints.EVENTS + `?where=ownerId%3D%27${userId}%27`;
    return api.get(url);
}