import { html, render } from '../node_modules/lit-html/lit-html.js';
import { repeat } from '../node_modules/lit-html/directives/repeat.js';

function component(inputClass, mode = 'closed') {

    class Cmp extends HTMLElement {

        constructor(...args) {
            super();
            const obj = new inputClass(...args);

            const prototypeNames = Object.getOwnPropertyNames(inputClass.prototype);
            const classNames = Object.getOwnPropertyNames(obj);

            for (const prop of prototypeNames.concat(classNames).filter(i => i !== 'constructor')) {

                if (obj.hasOwnProperty(prop)) {
                    let val = obj[prop];

                    Object.defineProperty(this, prop, {
                        set(newValue) {
                            val = newValue;
                            this._update();
                        },
                        get() {
                            return val;
                        }
                    });
                } else if (!Cmp.prototype[prop]) {
                    Cmp.prototype[prop] = obj[prop];
                }
            }

            const root = this.attachShadow({ mode });
            this.hasUpdateScheduled = false;

            this._update = function () {
                if (this.hasUpdateScheduled) { return; }

                Promise.resolve().then(() => {
                    const template = this.render();
                    render(template, root, { eventContext: this });
                    this.hasUpdateScheduled = false;
                });
            }

            this._update();
        }
    }

    return Cmp;
}

// Function if I do not use the above decorator
/* function getEditableListTemplate(context) {
    return html`<style>
    .container {
        max-width: 500px;
        margin: 50px auto;
        border-radius: 20px;
        border: solid 8px #2c3033;
        background: white;
        box-shadow: 0 0 0px 1px rgba(255, 255, 255, .4), 0 0 0px 3px #2c3033;
    }

    .editable-list-header {
        margin: 0;
        border-radius: 10px 10px 0 0px;
        background-image: linear-gradient(#687480 0%, #3b4755 100%);
        font: bold 18px/50px arial;
        text-align: center;
        color: white;
        box-shadow: inset 0 -2px 3px 2px rgba(0, 0, 0, .4), 0 2px 2px 2px rgba(0, 0, 0, .4);
    }

    .editable-list {
        padding-left: 0;
    }

    .editable-list>li,
    .editable-list-add-container {
        display: flex;
        align-items: center;
    }

    .editable-list>li {
        justify-content: space-between;
        padding: 0 1em;
    }

    .editable-list-add-container {
        justify-content: space-evenly;
    }

    .editable-list>li:nth-child(odd) {
        background-color: rgb(229, 229, 234);
    }

    .editable-list>li:nth-child(even) {
        background-color: rgb(255, 255, 255);
    }

    .editable-list-add-container>label {
        font-weight: bold;
        text-transform: uppercase;
    }

    .icon {
        background: none;
        border: none;
        cursor: pointer;
        font-size: 1.8rem;
        outline: none;
    }
</style>
<article class="container">
    <h1 class="editable-list-header">TODO LIST TITLE</h1>

    <ul class="editable-list" @click=${context.deleteItemHandler}>
       ${repeat(context.items, item => item.id, context.itemRenderFn)}
    </ul>

    <div class="editable-list-add-container">
        <label>ADD NEW TODO</label>
        <input @input=${context.itemInputHandler} .value=${context.inputValue} class="add-new-list-item-input" type="text" />
        <button class="editable-list-add-item icon" @click=${context.addItemHandler}>&oplus;</button>
    </div>
</article>
`;
}
*/

class EditableList {
    constructor() {
        this.inputValue = '';
        this.items = [];
    }

    itemInputHandler(event) {
        this.inputValue = event.target.value;
    }

    addItemHandler() {
        if (!this.inputValue) {
            alert('Please fill the input area.')
            return;
        }

        this.items.push({ text: this.inputValue });
        this.inputValue = '';
    }

    deleteItemHandler(event) {
        const target = event.target;

        if (!target.classList.contains('editable-list-remove-item')) { return; }
        const index = target.getAttribute('data-index');
        this.items = this.items.filter((_, i) => i !== Number(index));
    }

    itemRenderFn(item, index) {
        return html`<li>
        <p class="editable-list-item-value">${item.text}</p>
        <button data-index=${index} class="editable-list-remove-item icon">
            &ominus;
        </button>
        </li>
        `;
    }

    render() {
        return html`<style>
    .container {
        max-width: 500px;
        margin: 50px auto;
        border-radius: 20px;
        border: solid 8px #2c3033;
        background: white;
        box-shadow: 0 0 0px 1px rgba(255, 255, 255, .4), 0 0 0px 3px #2c3033;
    }

    .editable-list-header {
        margin: 0;
        border-radius: 10px 10px 0 0px;
        background-image: linear-gradient(#687480 0%, #3b4755 100%);
        font: bold 18px/50px arial;
        text-align: center;
        color: white;
        box-shadow: inset 0 -2px 3px 2px rgba(0, 0, 0, .4), 0 2px 2px 2px rgba(0, 0, 0, .4);
    }

    .editable-list {
        padding-left: 0;
    }

    .editable-list>li,
    .editable-list-add-container {
        display: flex;
        align-items: center;
    }

    .editable-list>li {
        justify-content: space-between;
        padding: 0 1em;
    }

    .editable-list-add-container {
        justify-content: space-evenly;
    }

    .editable-list>li:nth-child(odd) {
        background-color: rgb(229, 229, 234);
    }

    .editable-list>li:nth-child(even) {
        background-color: rgb(255, 255, 255);
    }

    .editable-list-add-container>label {
        font-weight: bold;
        text-transform: uppercase;
    }

    .icon {
        background: none;
        border: none;
        cursor: pointer;
        font-size: 1.8rem;
        outline: none;
    }
</style>
<article class="container">
    <h1 class="editable-list-header">TODO LIST TITLE</h1>

    <ul class="editable-list" @click=${this.deleteItemHandler}>
       ${repeat(this.items, item => item.id, this.itemRenderFn)}
    </ul>

    <div class="editable-list-add-container">
        <label>ADD NEW TODO</label>
        <input @input=${this.itemInputHandler} .value=${this.inputValue} class="add-new-list-item-input" type="text" />
        <button class="editable-list-add-item icon" @click=${this.addItemHandler}>&oplus;</button>
    </div>
</article>
`;
    }
}

customElements.define('editable-list', component(EditableList));