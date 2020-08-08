import home, { searchMovieGet } from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as movies from '../controllers/movies.js';

window.addEventListener('load', () => {
    const app = Sammy('#container', function () {

        this.use('Handlebars', 'hbs');

        this.userData = {
            email: localStorage.getItem('email') || '',
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

        this.get('#/create', movies.createMovieGet);
        this.post('#/create', (ctx) => { movies.createMoviePost.call(ctx); });

        this.get('#/edit/:id', movies.editMovieGet);
        this.post('#/edit/:id', (ctx) => { movies.editMoviePost.call(ctx); });

        this.get('#/like/:id', movies.likeMovieGet);
        this.get('#/delete/:id', movies.deleteMovieGet);

        this.get('#/details/:id', movies.detailsGet);

        this.get('#/search', searchMovieGet);
    });

    app.run('/');
});