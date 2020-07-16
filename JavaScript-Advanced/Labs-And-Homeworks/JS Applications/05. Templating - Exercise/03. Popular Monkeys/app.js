import { monkeys } from './monkeys.js';

(async function () {
    const monkeysSection = document.querySelector('section');

    await render();
    await attachEvents();

    async function render() {
        const monkeyCardTemplate = await fetch('./templates/monkey-card.hbs')
            .then(data => data.text());

        const monkeysTemplate = await fetch('./templates/monkeys.hbs')
            .then(data => data.text());

        Handlebars.registerPartial('monkey-card', monkeyCardTemplate);
        const template = Handlebars.compile(monkeysTemplate);

        const context = { monkeys };
        monkeysSection.innerHTML = template(context);
    }

    async function attachEvents() {
        try {
            // Instead of attaching event for each button I use the power of bubbling (event delegation) and attach one event
            monkeysSection.addEventListener('click', (e) => {
                const target = e.target;

                if (target.nodeName !== 'BUTTON') { return; }

                const currInfoParagraph = target.parentElement.querySelector('p');

                const btnTextSwitch = {
                    'Info': 'Hide',
                    'Hide': 'Info',
                };

                const displayStyleSwitch = {
                    'none': 'block',
                    'block': 'none'
                };

                target.textContent = btnTextSwitch[target.textContent];
                currInfoParagraph.style.display = displayStyleSwitch[currInfoParagraph.style.display];
            });
        } catch (error) {
            alert(error);
            return;
        }
    }
}());