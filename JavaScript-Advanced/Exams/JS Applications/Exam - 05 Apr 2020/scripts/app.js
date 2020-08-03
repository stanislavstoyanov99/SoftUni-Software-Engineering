import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as articles from '../controllers/articles.js';

window.addEventListener('load', () => {
    const app = Sammy('#root', function () {
        
        this.use('Handlebars', 'hbs');

        this.before('/', notifications.showLoader);
        this.before('index.html', notifications.showLoader);
        this.before('#/home', notifications.showLoader);

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

        this.get('#/create', articles.createArticleGet);
        this.post('#/create', (ctx) => { articles.createArticlePost.call(ctx); });

        this.get('#/edit/:id', articles.editArticleGet);
        this.post('#/edit/:id', (ctx) => { articles.editArticlePost.call(ctx); });

        this.get('#/delete/:id', articles.deleteArticlePost);

        this.get('#/details/:id', articles.detailsGet);
    });

    app.run('/');
});