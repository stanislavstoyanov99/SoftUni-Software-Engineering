import { render, html } from './node_modules/lit-html/lit-html.js';
import { repeat } from './node_modules/lit-html/directives/repeat.js';

const getAppRootTemplate = (context) => {
    const loader = html`<div>Loading...</div>`;
    const users = html`<user-list @select=${context.selectUserHandler} .users=${context.users || []}></user-list>`;

    return html`
    <button @click=${context.toggleDisabledHandler}>Toggle Disabled</button>
    <input ?disabled=${context.isDisabled} value="${context.inputValue}"/>

    ${context.isLoading ? loader : users}
    `;
};

const getUserListTemplate = (context) => {
    return html`<ul @click=${context.selectUserHandler}>${repeat(context._users, u => u.id, (user) => html`<li class="user-email" data-id=${user.id}>${user.email}</li>`)}</ul>`;
};

class AppRoot extends HTMLElement {

    get inputValue() {
        return this._inputValue || '';
    }

    set inputValue(newValue) {
        this._inputValue = newValue;
        this._update();
    }

    get isLoading() {
        return this._isLoading;
    }

    set isLoading(newValue) {
        this._isLoading = newValue;
        this._update();
    }

    get users() {
        return this._users;
    }

    set users(newValue) {
        this._users = newValue;
        this._update();
    }

    get isDisabled() {
        return this._isDisabled;
    }

    set isDisabled(newValue) {
        this._isDisabled = newValue;
        this._update();
    }

    toggleDisabledHandler() {
        this.isDisabled = !this.isDisabled;
    }

    constructor() {
        super();
        this.attachShadow({ mode: 'open' });

        this.isLoading = false;
        this.users = [];
    }

    selectUserHandler(event) {
        this.inputValue = event.detail.userId;
    }

    connectedCallback() {
        this.loadUsers().then(users => {
            this.isLoading = false;
            this.users = users;
        });
    }

    loadUsers() {
        this.isLoading = true;
        return fetch('https://jsonplaceholder.typicode.com/users')
            .then(res => res.json());
    }
}

function withUpdate(inputClass, templateFn) {
    inputClass.prototype.hasUpdateScheduled = false;
    inputClass.prototype._update = function componentUpdate() {
        if (this.hasUpdateScheduled) { return; }

        Promise.resolve().then(() => {
            const template = templateFn(this);
            render(template, this.shadowRoot, { eventContext: this });
            this.hasUpdateScheduled = false;
        });
    }

    return inputClass;
}

customElements.define('app-root', withUpdate(AppRoot, getAppRootTemplate))

class UserList extends HTMLElement {
    get users() {
        return this._users;
    }

    set users(newValue) {
        this._users = newValue;
        this._update();
    }

    selectUserHandler(event) {
        const target = event.target;
        if (!target.classList.contains('user-email')) { return; }

        const userId = target.getAttribute('data-id');
        this.dispatchEvent(new CustomEvent('select', {detail: { userId }}));
    }

    constructor() {
        super();
        this.attachShadow({ mode: 'open' });
        this.users = [];
    }
}

customElements.define('user-list', withUpdate(UserList, getUserListTemplate));