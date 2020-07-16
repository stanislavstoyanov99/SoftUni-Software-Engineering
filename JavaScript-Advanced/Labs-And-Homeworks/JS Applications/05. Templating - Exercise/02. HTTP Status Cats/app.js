(async function () {
    const allCatsSection = document.querySelector('#allCats');

    await render();
    await attachEvents();

    async function render() {
        const catCardTemplate = await fetch('./templates/cat-card.hbs')
            .then(data => data.text());

        const catsTemplate = await fetch('./templates/cats.hbs')
            .then(data => data.text());

        Handlebars.registerPartial('cat-card', catCardTemplate);
        const template = Handlebars.compile(catsTemplate);

        const cats = window.cats;
        const context = { cats };
        allCatsSection.innerHTML = template(context);
    }

    async function attachEvents() {
        try {
            // Instead of attaching event for each button I use the power of bubbling and attach one event
            allCatsSection.addEventListener('click', (e) => {
                const target = e.target;

                if (!target.classList.contains('showBtn')) { return; }

                const currDetailsEl = target.parentElement.querySelector('.status');

                currDetailsEl.style.display = currDetailsEl.style.display === 'none' ? 'block' : 'none';
                target.textContent = target.textContent === 'Show status code' ? 'Hide status code' : 'Show status code';
            });
        } catch (error) {
            alert(error);
            return;
        }
    }
}());