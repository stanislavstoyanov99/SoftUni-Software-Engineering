export default class API {
    constructor(appId, restApiKey, endpoints) {
        this.appId = appId;
        this.restApiKey = restApiKey;
        this.endpoints = Object.assign({
            REGISTER: 'users/register',
            LOGIN: 'users/login',
            LOGOUT: 'users/logout',
            USERS: 'data/Users'
        }, endpoints);
    }

    host(endpoint) {
        return `https://api.backendless.com/${this.appId}/${this.restApiKey}/${endpoint}`;
    }

    getOptions(headers) {
        const token = sessionStorage.getItem('userToken');

        const options = { headers: headers || {} };

        if (token !== null) {
            Object.assign(options.headers, { 'user-token': token });
        }

        return options;
    }

    async get(endpoint) {
        if (endpoint === 'users/logout') {
            return await fetch(this.host(endpoint), this.getOptions());
        }

        return (await fetch(this.host(endpoint), this.getOptions())).json();
    }

    async post(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'POST';
        options.body = JSON.stringify(body);

        return (await fetch(this.host(endpoint), options)).json();
    }

    async put(endpoint, body) {
        const options = this.getOptions({ 'Content-Type': 'application/json' });

        options.method = 'PUT';
        options.body = JSON.stringify(body);

        return (await fetch(this.host(endpoint), options)).json();
    }

    async delete(endpoint) {
        const options = this.getOptions();

        options.method = 'DELETE';

        return (await fetch(this.host(endpoint), options)).json();
    }

    async register(user) {
        return await this.post(this.endpoints.REGISTER, user);
    }

    async login(user) {
        const result = await this.post(this.endpoints.LOGIN, user);

        if (result.code) {
            throw result;
        }

        sessionStorage.setItem('userToken', result['user-token']);
        sessionStorage.setItem('username', result.username);
        sessionStorage.setItem('userId', result.objectId);
        sessionStorage.setItem('firstName', result.firstName);
        sessionStorage.setItem('lastName', result.lastName);

        return result;
    }

    async logout() {
        const result = await this.get(this.endpoints.LOGOUT);

        if (result.code) {
            throw result;
        }

        sessionStorage.removeItem('userToken');
        sessionStorage.removeItem('username');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('firstName');
        sessionStorage.removeItem('lastName');

        return result;
    }
}