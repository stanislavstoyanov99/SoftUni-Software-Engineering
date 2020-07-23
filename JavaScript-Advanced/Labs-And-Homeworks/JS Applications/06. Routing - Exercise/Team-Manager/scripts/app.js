import home from '../controllers/home.js';
import about from '../controllers/about.js';
import * as users from '../controllers/users.js';
import * as catalog from '../controllers/catalog.js';
import * as team from '../controllers/team.js';

window.addEventListener('load', () => {
    const app = Sammy('#main', function () {
        
        this.use('Handlebars', 'hbs');

        this.userData = {
            loggedIn: false,
            hasTeam: false,
            username: undefined,
            userId: undefined,
            teamId: undefined,
        };

        this.get('index.html', home);
        this.get('#/home', home);
        this.get('/', home);

        this.get('#/about', about);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });
        
        this.get('#/logout', users.logoutGet);

        this.get('#/catalog', catalog.teamCatalog);
        this.get('#/catalog/:id', catalog.teamDetails);

        this.get('#/create', catalog.createTeamGet);
        this.post('#/create', (ctx) => { catalog.createTeamPost.call(ctx); });

        this.get('#/edit/:id', team.editTeamGet);
        this.post('#/edit/:id', (ctx) => { team.editTeamPost.call(ctx); });

        this.get('#/join/:id', team.joinTeam);
        this.get('#/leave', team.leaveTeam);
    });

    app.run();
});