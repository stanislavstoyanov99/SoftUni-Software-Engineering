import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as movies from '../controllers/movies.js';
import * as catalog from '../controllers/catalog.js';

window.addEventListener('load', () => {
    const app = Sammy('#container', function () {
        
        this.use('Handlebars', 'hbs');

        this.before('/', notifications.showLoader);
        this.before('index.html', notifications.showLoader);
        this.before('#/home', notifications.showLoader);

        this.userData = {
            username: localStorage.getItem('username') || '',
            userId: localStorage.getItem('userId') || '',
        };

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });
        
        this.get('#/logout', users.logoutGet);

        this.get('#/create', movies.createGet);
        this.post('#/create', (ctx) => { movies.createPost.call(ctx); });

        this.get('#/catalog', catalog.allMovies);
        this.get('#/details/:id', movies.detailsGet);

        this.get('#/buy/:id', movies.buyTicketGet);

        this.get('#/myMovies', catalog.myMovies);
    });

    app.run('/');
});