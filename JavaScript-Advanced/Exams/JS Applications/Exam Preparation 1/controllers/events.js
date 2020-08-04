import { apiCreateEvent, apiEditEvent, apiDeleteEvent, getEventById } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';

export async function createEventGet() {
    notifications.showLoader();

    const token = validateToken(this);

    if (!token) {
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
    const token = validateToken(this);

    if (!token) {
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

    if (!(moment(`${this.params.dateTime}`, 'DD-MM-YYYY HH:mm', true).isValid())) {
        errors.push('Event date should be valid in format "DD-MM-YYYY HH:mm".');
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
        const createdEvent = await apiCreateEvent(event);

        if (createdEvent.code) {
            throw createdEvent;
        }

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
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let event = {};

    try {
        notifications.showLoader();
        event = await getEventById(this.params.id);

        if (event.code) {
            throw event;
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

    this.partial('./templates/events/edit.hbs', event);
}

export async function editEventPost() {
    const token = validateToken(this);

    if (!token) {
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

    if (!(moment(`${this.params.dateTime}`, 'DD-MM-YYYY HH:mm', true).isValid())) {
        errors.push('Event date should be valid in format "DD-MM-YYYY HH:mm".');
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
        const editedEvent = await apiEditEvent(event, this.params.id);

        if (editedEvent.code) {
            throw editedEvent;
        }

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
    const token = validateToken(this);

    if (!token) {
        return;
    }

    try {
        notifications.showLoader();

        const deletionTime = await apiDeleteEvent(this.params.id);

        if (deletionTime.code) {
            throw deletionTime;
        }

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
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let event = {};

    try {
        notifications.showLoader();
        event = await getEventById(this.params.id);

        if (event.code) {
            throw event;
        }

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
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let event = {};

    try {
        notifications.showLoader();
        event = await getEventById(this.params.id);

        if (event.code) {
            throw event;
        }

        if (event.organizer === this.app.userData.username) {
            throw new Error('You cannot join event organized by you.');
        }

        event.people++;
        const editedEvent = await apiEditEvent(event, this.params.id);

        if (editedEvent.code) {
            throw editedEvent;
        }

        notifications.hideLoader();
        notifications.showNotification('You joined the event successfully.', 'info');     
        this.redirect(`#/details/${this.params.id}`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}