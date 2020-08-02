class ExpandingList extends HTMLUListElement {
    constructor() {
        super();
        this.addEventListener('click', this.clickHandler);

        const listItems = [...this.querySelectorAll('li')];

        listItems.forEach(item => {
            if (item.children.length > 0) {
                item.classList.add('closed');
            }
        });
    }

    clickHandler(event) {
        const target = event.target;
        if (target.nodeName !== 'LI' || target.children.length === 0) { return; }
    
        if (target.classList.contains('closed')) {
            target.classList.remove('closed');
            target.classList.add('open');
        } else {
            target.classList.add('closed');
            target.classList.remove('open');
        }
    }
}

customElements.define('expanding-list', ExpandingList, { extends: 'ul' });