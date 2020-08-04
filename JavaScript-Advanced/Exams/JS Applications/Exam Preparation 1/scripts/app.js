import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as events from '../controllers/events.js';

window.addEventListener('load', () => {
    const app = Sammy('#root', function () {

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

        this.get('#/organize', events.createEventGet);
        this.post('#/organize', (ctx) => { events.createEventPost.call(ctx); });

        this.get('#/edit/:id', events.editEventGet);
        this.post('#/edit/:id', (ctx) => { events.editEventPost.call(ctx); });

        this.get('#/join/:id', events.joinEventGet);
        this.get('#/close/:id', events.deleteEventGet);

        this.get('#/details/:id', events.detailsGet);
    });

    app.run('/');
});