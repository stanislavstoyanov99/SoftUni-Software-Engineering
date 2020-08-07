import { apiCreateEvent, apiEditEvent, apiDeleteEvent, apiJoinEvent, getEventById } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import validateUser from '../scripts/validateUser.js';

export async function createEventGet() {
    notifications.showLoader();

    if (!validateUser()) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/events/create.hbs', this.app.userData);
    notifications.hideLoader();
}

export async function createEventPost() {
    if (!validateUser()) {
        return;
    }

    const errors = [];

    if (!this.params.name ||
        !this.params.dateTime ||
        !this.params.description ||
        !this.params.imageURL) {
        errors.push('All input fields are required.');
    }

    if (this.params.name.length < 6) {
        errors.push('The event name should be at least 6 characters long.');
    }

    if (!(moment(`${this.params.dateTime}`, 'DD MMMM HH:mm a', true).isValid())) {
        errors.push('Event date should be valid in format "DD MMMM HH:mm PM or AM".');
    }

    if (this.params.description.length < 10) {
        errors.push('The description should be at least 10 characters long.');
    }

    if (!this.params.imageURL.startsWith('https://') && !this.params.imageURL.startsWith('http://')) {
        errors.push('The image should start with "https://" or "http://".');
    }

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const event = {
        name: this.params.name,
        dateTime: this.params.dateTime,
        description: this.params.description,
        image: this.params.imageURL,
        organizer: this.app.userData.username,
        people: 0
    };

    try {
        notifications.showLoader();
        await apiCreateEvent(event);

        notifications.hideLoader();
        notifications.showNotification('Event created successfully.', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function editEventGet() {
    if (!validateUser()) {
        return;
    }

    let event = {};

    try {
        notifications.showLoader();
        const response = await getEventById(this.params.id);
        event = response.data();
        event.id = response.id;

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

    Object.assign(event, this.app.userData);

    this.partial('./templates/events/edit.hbs', event);
}

export async function editEventPost() {
    if (!validateUser()) {
        return;
    }

    const errors = [];

    if (!this.params.name ||
        !this.params.dateTime ||
        !this.params.description ||
        !this.params.imageURL) {
        errors.push('All input fields are required.');
    }

    if (this.params.name.length < 6) {
        errors.push('The event name should be at least 6 characters long.');
    }

    if (!(moment(`${this.params.dateTime}`, 'DD MMMM HH:mm a', true).isValid())) {
        errors.push('Event date should be valid in format "DD MMMM HH:mm PM or AM".');
    }

    if (this.params.description.length < 10) {
        errors.push('The description should be at least 10 characters long.');
    }

    if (!this.params.imageURL.startsWith('https://') && !this.params.imageURL.startsWith('http://')) {
        errors.push('The image should start with "https://" or "http://".');
    }

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const event = {
        name: this.params.name,
        dateTime: this.params.dateTime,
        description: this.params.description,
        image: this.params.imageURL,
        organizer: this.app.userData.username
    };

    try {
        notifications.showLoader();
        await apiEditEvent(event, this.params.id);

        notifications.hideLoader();
        notifications.showNotification('Event edited successfully.', 'info');

        this.redirect(`#/home`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function deleteEventGet() {
    if (!validateUser()) {
        return;
    }

    try {
        notifications.showLoader();

        await apiDeleteEvent(this.params.id);

        notifications.hideLoader();
        notifications.showNotification('Event closed successfully.', 'info');
        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function detailsGet() {
    if (!validateUser()) {
        return;
    }

    let event = {};

    try {
        notifications.showLoader();
        const response = await getEventById(this.params.id);
        event = response.data();
        event.id = response.id;

        if (event.organizer === this.app.userData.username) {
            event.isOrganizer = true;
        } else {
            event.isOrganizer = false;
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

    Object.assign(event, this.app.userData);

    this.partial('./templates/events/details.hbs', event);
}

export async function joinEventGet() {
    if (!validateUser()) {
        return;
    }
    
    try {
        notifications.showLoader();

        const response = await getEventById(this.params.id);
        const currEvent = response.data();
        if (currEvent.organizer === this.app.userData.username) {
            throw new Error('You cannot join event organized by you.');
        }

        await apiJoinEvent(this.params.id);

        notifications.hideLoader();
        notifications.showNotification('You joined the event successfully.', 'info');     
        this.redirect(`#/details/${this.params.id}`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}