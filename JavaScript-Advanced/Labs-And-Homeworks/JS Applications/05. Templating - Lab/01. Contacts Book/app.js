(async function fillContacts() {
    const contactCardTemplate = await fetch('./templates/contact-card.hbs')
        .then(data => data.text());

    const contactsTemplate = await fetch('./templates/contacts.hbs')
        .then(data => data.text());

    const contacts = await fetch('contacts.json')
        .then(data => data.json());

    const contactsDiv = document.getElementById("contacts");

    Handlebars.registerPartial('contact-card', contactCardTemplate);
    const template = Handlebars.compile(contactsTemplate);

    const context = { contacts };
    contactsDiv.innerHTML = template(context);

    contactsDiv.addEventListener('click', (e) => {
        const target = e.target;

        if(!target.classList.contains('detailsBtn')) { return; }

        const currDetailsEl = target.parentElement.querySelector('.details');

        if (currDetailsEl.classList.contains('hidden')) {
            currDetailsEl.classList.remove('hidden');
        } else {
            currDetailsEl.classList.add('hidden');
        }
    });
}());