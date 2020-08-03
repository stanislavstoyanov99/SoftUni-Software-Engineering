import * as notifications from '../scripts/notifications.js';
import { getArticleByCategory } from '../scripts/data.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        article: await this.load('./templates/articles/article.hbs'),
        loginForm: await this.load('./templates/users/loginForm.hbs'),
        login: await this.load('./templates/users/login.hbs')
    };

    let data = {};

    try {
        notifications.showLoader();

        data.cSharpArticles = await getArticleByCategory('C#');
        if (data.cSharpArticles.code) {
            throw data.cSharpArticles;
        }

        data.javaArticles = await getArticleByCategory('Java');
        if (data.javaArticles.code) {
            throw data.javaArticles;
        }

        data.jsArticles = await getArticleByCategory('JavaScript');
        if (data.jsArticles.code) {
            throw data.jsArticles;
        }

        data.pythonArticles = await getArticleByCategory('Python');
        if (data.pythonArticles.code) {
            throw data.pythonArticles;
        }

        Object.values(data)
            .forEach(obj => obj.sort((a1, a2) => (a2.title).localeCompare(a1.title)));

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    Object.assign(data, this.app.userData);

    this.partial('./templates/home/home.hbs', data);
}