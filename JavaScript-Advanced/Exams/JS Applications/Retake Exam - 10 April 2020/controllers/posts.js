import { apiCreatePost, apiEditPost, apiDeletePost, getPostById } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function createPost() {
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

    const post = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content
    };

    try {
        notifications.showLoader();
        const createdPost = await apiCreatePost(post);

        if (createdPost.code) {
            throw createdPost;
        }

        notifications.hideLoader();
        notifications.showNotification(`Post with title ${post.title} has been created successfully.`, 'info');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function editGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let post = {};

    try {
        notifications.showLoader();
        post = await getPostById(this.params.id);

        if (post.code) {
            throw post;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        editForm: await this.load('./templates/posts/editForm.hbs')
    };

    Object.assign(post, this.app.userData);

    this.partial('./templates/posts/edit.hbs', post);
}

export async function editPost() {
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

    const post = {
        title: this.params.title,
        category: this.params.category,
        content: this.params.content
    };

    try {
        notifications.showLoader();
        const editedPost = await apiEditPost(post, this.params.id);

        if (editedPost.code) {
            throw editedPost;
        }

        notifications.hideLoader();
        notifications.showNotification(`Post with title ${editedPost.title} has been edited successfully.`, 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function deletePost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        notifications.showLoader();

        await apiDeletePost(this.params.id);

        notifications.hideLoader();
        notifications.showNotification('Post has been removed successfully', 'info');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    this.redirect('#/home');
}

export async function detailsGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let post = {};
    try {
        notifications.showLoader();
        post = await getPostById(this.params.id);

        if (post.code) {
            throw post;
        }

        notifications.hideLoader();
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs')
    };

    Object.assign(post, this.app.userData);

    this.partial('./templates/posts/details.hbs', post);
}