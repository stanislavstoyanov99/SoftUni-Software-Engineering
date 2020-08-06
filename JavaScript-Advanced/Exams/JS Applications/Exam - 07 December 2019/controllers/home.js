import { getAllTreks } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        trek: await this.load('./templates/home/trek.hbs'),
        notFound: await this.load('./templates/home/notFound.hbs')
    };

    let data = {};

    try {
        notifications.showLoader();

        data.treks = await getAllTreks();
        if (data.treks.code) {
            throw data.treks;
        }

        Object.values(data)
            .forEach(obj => obj.sort((t1, t2) => t2.likes - t1.likes));

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    Object.assign(data, this.app.userData);

    this.partial('./templates/home/home.hbs', data);
}