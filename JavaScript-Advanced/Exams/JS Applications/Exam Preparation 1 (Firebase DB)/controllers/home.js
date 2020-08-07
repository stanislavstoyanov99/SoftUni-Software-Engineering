import { getAllEvents } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export default async function () {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        event: await this.load('./templates/home/event.hbs'),
        notFound: await this.load('./templates/home/notFound.hbs')
    };

    let data = {};

    try {
        notifications.showLoader();

        const response = await getAllEvents();
        data.events = response.docs.map(x => x = { ...x.data(), id: x.id } );

        if (data.events.length !== 0) {
            data.events.sort((e1, e2) => e2.people - e1.people);
        }

        notifications.hideLoader();
    } catch (error) {
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }

    Object.assign(data, this.app.userData);

    this.partial('./templates/home/home.hbs', data);
}