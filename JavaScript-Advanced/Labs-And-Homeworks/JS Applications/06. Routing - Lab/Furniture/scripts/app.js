import home from '../controllers/home.js';
import createFurniture from '../controllers/createFurniture.js';
import myFurniture from '../controllers/myFurniture.js';
import * as manageFurniture from '../controllers/furniture.js';

const loader = document.querySelector('#loadingBox');

(function toggleNavbar() {
    const navigation = document.querySelector("#navigation");
    const navigationTabs = [...navigation.querySelectorAll('li > #navigation-tab')];

    navigation.addEventListener('click', onClick);

    function onClick(e) {
        if (e.target.nodeName !== 'A') { return; }

        navigationTabs.forEach(tab => {
            tab.classList.remove('active');
        });

        e.target.classList.add('active');
    }
}());

window.addEventListener('load', () => {
    const app = Sammy('#container', function () {
        this.use('Handlebars', 'hbs');

        this.before({}, function () {
            loader.style.display = 'block';
        });

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);
        this.get('#/furniture/all', home);

        this.get('#/furniture/create', createFurniture);
        this.get('#/furniture/details/:id', manageFurniture.furnitureDetails);
        this.get('#/furniture/all/:id', manageFurniture.likeFurniture);

        this.post('#/furniture/create', () => false);

        this.get('#/furniture/mine', myFurniture);
        this.get('#/furniture/mine/:id', manageFurniture.dislikeFurniture);
    });

    app.run();
});