(async function attachEvents() {
    const elements = {
        loadBtn() { return document.getElementById('btnLoadTowns') },
        townsInput() { return document.getElementById('towns') },
        rootDiv() { return document.getElementById('root') }
    };

    elements.rootDiv().innerHTML = '';

    try {
        const townsTemplate = await fetch('./templates/towns.hbs')
            .then(data => data.text());

        const template = Handlebars.compile(townsTemplate);

        elements.loadBtn().addEventListener('click', (e) => {
            e.preventDefault();

            if (!elements.townsInput().value) { 
                alert('Please fill the input.'); 
                return;
            }

            const towns = elements.townsInput().value.split(', ');
            const context = { towns };

            elements.rootDiv().innerHTML = template(context);
            elements.townsInput().value = '';
        });
    } catch (error) {
        alert(error);
        return;
    }
})();