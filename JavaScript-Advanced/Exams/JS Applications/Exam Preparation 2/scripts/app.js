import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as recipes from '../controllers/recipes.js';

window.addEventListener('load', () => {
    const app = Sammy('#rooter', function () {

        this.use('Handlebars', 'hbs');

        this.before('/', notifications.showLoader);
        this.before('index.html', notifications.showLoader);
        this.before('#/home', notifications.showLoader);

        this.userData = {
            username: sessionStorage.getItem('username') || '',
            userId: sessionStorage.getItem('userId') || '',
            firstName: sessionStorage.getItem('firstName') || '',
            lastName: sessionStorage.getItem('lastName') || ''
        };

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });

        this.get('#/logout', users.logoutGet);

        this.get('#/share', recipes.createRecipeGet);
        this.post('#/share', (ctx) => { recipes.createRecipePost.call(ctx); });

        this.get('#/edit/:id', recipes.editRecipeGet);
        this.post('#/edit/:id', (ctx) => { recipes.editRecipePost.call(ctx); });

        this.get('#/like/:id', recipes.likeRecipeGet);
        this.get('#/archive/:id', recipes.deleteRecipeGet);

        this.get('#/details/:id', recipes.detailsGet);
    });

    app.run('/');
});