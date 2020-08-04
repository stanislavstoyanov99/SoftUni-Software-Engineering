import { apiCreateArticle, apiEditArticle, apiDeleteArticle, getArticleById } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function createArticleGet() {
    notifications.showLoader();

    const token = validateToken(this);

    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/articles/createForm.hbs')
    };

    this.partial('./templates/articles/create.hbs', this.app.userData);
    notifications.hideLoader();
}

export async function createArticlePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    if (!this.params.title ||
        !this.params.category ||
        !this.params.content) {
        notifications.showNotification('All input fields are required.', 'error');
        return;
    }

    if (this.params.title.length < 2) {
        notifications.showNotification('The title should be at least 2 characters long.', 'error');
        return;
    }

    const avaibleCategories = ['c#', 'java', 'javascript', 'python'];

    if (avaibleCategories.every(c => c !== this.params.category.toLowerCase())) {
        notifications.showNotification('Category should be one of: JavaScript, Java, Pyton or C#!', 'error');
        return;
    }

    const article = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content,
        creatorEmail: this.app.userData.email
    };

    try {
        notifications.showLoader();
        const createdArticle = await apiCreateArticle(article);

        if (createdArticle.code) {
            throw createdArticle;
        }

        notifications.hideLoader();
        notifications.showNotification(`Article with title ${article.title} has been created successfully.`, 'info');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function editArticleGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let article = {};

    try {
        notifications.showLoader();
        article = await getArticleById(this.params.id);

        if (article.code) {
            throw article;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/articles/editForm.hbs')
    };

    Object.assign(article, this.app.userData);

    this.partial('./templates/articles/edit.hbs', article);
}

export async function editArticlePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    if (!this.params.title ||
        !this.params.category ||
        !this.params.content) {
        notifications.showNotification('All input fields are required.', 'error');
        return;
    }

    if (this.params.title.length < 2) {
        notifications.showNotification('The title should be at least 2 characters long.', 'error');
        return;
    }

    const avaibleCategories = ['c#', 'java', 'javascript', 'python'];

    if (avaibleCategories.every(c => c !== this.params.category.toLowerCase())) {
        notifications.showNotification('Category should be one of: JavaScript, Java, Pyton or C#!', 'error');
        return;
    }

    const article = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content,
        creatorEmail: this.app.userData.email
    };

    try {
        notifications.showLoader();
        const editedArticle = await apiEditArticle(article, this.params.id);

        if (editedArticle.code) {
            throw editedArticle;
        }

        notifications.hideLoader();
        notifications.showNotification(`Article with title ${article.title} has been edited successfully.`, 'info');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function deleteArticleGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        notifications.showLoader();

        await apiDeleteArticle(this.params.id);

        notifications.hideLoader();
        notifications.showNotification('Article has been removed successfully', 'info');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.redirect('#/home');
}

export async function detailsGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let article = {};

    try {
        notifications.showLoader();
        article = await getArticleById(this.params.id);

        if (article.code) {
            throw article;
        }

        if (article.ownerId === this.app.userData.userId) {
            article.isCreator = true;
        } else {
            article.isCreator = false;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    Object.assign(article, this.app.userData);

    this.partial('./templates/articles/details.hbs', article);
}