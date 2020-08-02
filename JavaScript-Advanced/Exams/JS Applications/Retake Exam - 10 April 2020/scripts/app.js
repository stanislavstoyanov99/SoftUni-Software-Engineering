import home from '../controllers/home.js';
import * as users from '../controllers/users.js';
import * as notifications from './notifications.js';
import * as posts from '../controllers/posts.js';

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

        this.post('#/create-post', (ctx) => { posts.createPost.call(ctx); });

        this.get('#/edit/:id', posts.editGet);
        this.post('#/edit/:id', (ctx) => { posts.editPost.call(ctx); });

        this.get('#/delete/:id', posts.deletePost);

        this.get('#/details/:id', posts.detailsGet);
    });

    app.run('/');
});