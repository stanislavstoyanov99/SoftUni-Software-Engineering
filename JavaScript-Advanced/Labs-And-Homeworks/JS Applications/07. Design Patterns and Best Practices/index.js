import { match } from './node_modules/path-to-regexp/dist.es2015/index.js';

function Sammy(selector, initFn) {
    const mainElement = document.querySelector(selector);
    const getPathCollection = [];
    const postPathCollection = [];
    const putPathCollection = [];
    let currentPath;

    function setupAnchorHandlers() {
        [...document.querySelectorAll('a')].forEach(
            i => {
                if (i.hasAttribute('data-has-handler')) { return; }
                i.addEventListener('click', onAchorClickHandler);
                i.setAttribute('data-has-handler', true);
            });
    }

    function setupFormSubmissionHandlers(cb) {
        [...document.querySelectorAll('form')].forEach(
            f => {
                if (f.hasAttribute('data-has-handler')) { return; }
                f.addEventListener('submit', cb);
                f.setAttribute('data-has-handler', true);
            });
    }

    function setupListeners() {
        setupAnchorHandlers();

        window.addEventListener('popstate', function () {
            core.redirect(window.location.pathname);
        });
    }

    function onAchorClickHandler(e) {
        e.preventDefault();
        const target = e.target;
        const path = target.getAttribute('href');

        core.redirect(path);
        window.history.pushState(null, '', path);
    }

    const core = {
        get(path, fn) {
            const matchFn = match(path, { decode: decodeURIComponent });
            getPathCollection.push({ path, fn, matchFn });
        },
        post(path, fn) {
            const matchFn = match(path, { decode: decodeURIComponent });
            postPathCollection.push({ path, fn, matchFn });
        },
        put(path, fn) {
            const matchFn = match(path, { decode: decodeURIComponent });
            putPathCollection.push({ path, fn, matchFn });
        },
        load(url) {
            return fetch(url).then(res => {
                return res.json();
            });
        },
        redirect(path) {
            currentPath = path;
            let params;
            const pathObj = getPathCollection.find(i => {
                const data = i.matchFn(currentPath);
                if (data) { params = data.params; }
                return !!data;
            });

            if (!pathObj) {
                console.error(`body 404 Not Found get ${currentPath}`);
                return;
            }

            pathObj.fn.call(core, { params });

            setupAnchorHandlers();
        },
        swap(htmlContent) {
            mainElement.innerHTML = htmlContent;
            setTimeout(setupAnchorHandlers, 0);
            setTimeout(() => setupFormSubmissionHandlers(this._formSubmissionHandler), 0);
            setTimeout(() => setupFormSubmissionHandlers(this._formEditHandler), 0);
        },
        _formSubmissionHandler(e) {
            e.preventDefault();
            const target = e.target;
            if (target.method.toLowerCase() !== 'post') { return; }

            let params;
            const pathObj = postPathCollection.find(i => {
                const path = target.action.replace(location.protocol + '//' + location.host, '');
                const data = i.matchFn(path);

                if (data) { params = data.params; }
                
                return !!data;
            });

            if (!pathObj) {
                console.error(`body 404 Not Found post ${target.action}`);
                return;
            }

            pathObj.fn.call(core, { params, form: target });
        },
        _formEditHandler(e) {
            e.preventDefault();
            const target = e.target;
            if (target.method.toLowerCase() !== 'put') { return; }

            let params;
            const pathObj = putPathCollection.find(i => {
                const path = target.action.replace(location.protocol + '//' + location.host, '');
                const data = i.matchFn(path);

                if (data) { params = data.params; }
                
                return !!data;
            });

            if (!pathObj) {
                console.error(`body 404 Not Found put ${target.action}`);
                return;
            }

            pathObj.fn.call(core, { params, form: target });
        }
    };

    const app = {
        run(path) {
            setupListeners();
            initFn.call(core);

            core.redirect(path);
        }
    };

    return app;
}

const app = Sammy('#main', function () {
    this.get('/', function () {
        const ul = document.createElement('ul');
        this.load('https://jsonplaceholder.typicode.com/users').then(users => {
            users.forEach(user => {
                const li = document.createElement('li');
                const a = document.createElement('a');
                a.href = `/user/${user.id}`;
                a.textContent = user.email;
                li.appendChild(a);
                ul.appendChild(li);
            });

            const panel = `${ul.outerHTML} <form method="post" action="/create"><input name="name" value="" /><button>Save</button></form>`;
            this.swap(panel);
        });
    });

    this.post('/create', async function (context) {
        const url = 'https://jsonplaceholder.typicode.com/users';
        const email = context.form[0].value;

        const createdUser = (await fetch(url, {
            method: 'POST',
            body: JSON.stringify({
                email
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        })).json();

        this.redirect('/');
    });

    this.get('/user/:id', function (context) {
        this.swap('<div>Loading...</div>');
        this.load(`https://jsonplaceholder.typicode.com/users/${context.params.id}`)
            .then(user => { this.swap(`<h1>${user.email}</h1>`); });
    });

    this.get('/about', function () {
        this.swap('<h1>ABOUT PAGE</h1>');
    });
});

app.run(location.pathname);