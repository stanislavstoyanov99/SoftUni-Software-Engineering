import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as treks from '../controllers/treks.js';

window.addEventListener('load', () => {
    const app = Sammy('#rooter', function () {

        this.use('Handlebars', 'hbs');

        this.before('/', notifications.showLoader);
        this.before('index.html', notifications.showLoader);
        this.before('#/home', notifications.showLoader);

        this.userData = {
            username: localStorage.getItem('username') || '',
            userId: localStorage.getItem('userId') || ''
        };

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });

        this.get('#/logout', users.logoutGet);

        this.get('#/profile/:id', users.profileGet);

        this.get('#/request', treks.createTrekGet);
        this.post('#/request', (ctx) => { treks.createTrekPost.call(ctx); });

        this.get('#/edit/:id', treks.editTrekGet);
        this.post('#/edit/:id', (ctx) => { treks.editTrekPost.call(ctx); });

        this.get('#/like/:id', treks.likeTrekGet);
        this.get('#/close/:id', treks.deleteTrekGet);

        this.get('#/details/:id', treks.detailsGet);
    });

    app.run('/');
});