import * as notifications from '../scripts/notifications.js';
import { getAllPosts } from '../scripts/data.js';

export default async function() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        post: await this.load('./templates/posts/post.hbs'),
        createPost: await this.load('./templates/posts/createPost.hbs')
    };

    const data = Object.assign({}, this.app.userData);
    data.posts = [];

    try {
        notifications.showLoader();
        data.posts = await getAllPosts();

        if (data.posts.code) {
            throw data.posts;
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');  
    }

    this.partial('./templates/home/home.hbs', data);

    notifications.hideLoader();
}