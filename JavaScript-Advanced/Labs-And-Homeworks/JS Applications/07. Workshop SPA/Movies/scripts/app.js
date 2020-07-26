import home from '../controllers/home.js';
import * as users from '../controllers/users.js';

window.addEventListener('load', () => {
    const app = Sammy('#container', function () {
        
        this.use('Handlebars', 'hbs');

        this.userData = {
            username: undefined,
            userId: undefined,
        };

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });
        
        this.get('#/logout', users.logoutGet);
    });

    app.run();
});