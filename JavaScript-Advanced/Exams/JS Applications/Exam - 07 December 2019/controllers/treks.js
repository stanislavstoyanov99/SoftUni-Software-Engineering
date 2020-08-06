import { apiCreateTrek, apiEditTrek, apiDeleteTrek, likeTrek, getTrekById } from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';
import { validateToken } from '../scripts/tokenValidation.js';
import validateErrors from '../scripts/validateErrors.js';

export async function createTrekGet() {
    notifications.showLoader();

    const token = validateToken(this);

    if (!token) {
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/treks/create.hbs', this.app.userData);
    notifications.hideLoader();
}

export async function createTrekPost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const errors = validateErrors(this);

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const trek = {
        location: this.params.location,
        dateTime: this.params.dateTime,
        description: this.params.description,
        imageURL: this.params.imageURL,
        organizer: this.app.userData.username
    };

    try {
        notifications.showLoader();
        const createdTrek = await apiCreateTrek(trek);

        if (createdTrek.code) {
            throw createdTrek;
        }

        notifications.hideLoader();
        notifications.showNotification('Trek created successfully.', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function editTrekGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let trek = {};

    try {
        notifications.showLoader();

        trek = await getTrekById(this.params.id);

        if (trek.code) {
            throw trek;
        }

        if (trek.organizer !== this.app.userData.username) {
            notifications.showNotification('You cannot edit trek which is not created by you.', 'error');
            notifications.hideLoader();
            return;
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

    Object.assign(trek, this.app.userData);

    this.partial('./templates/treks/edit.hbs', trek);
}

export async function editTrekPost() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const errors = validateErrors(this);

    if (errors.length !== 0) {
        notifications.showNotification(errors.join(' '), 'error');
        return;
    }

    const currTrek = await getTrekById(this.params.id);
    if (currTrek.organizer !== this.app.userData.username) {
        notifications.showNotification('You cannot edit trek which is not created by you.', 'error');
        notifications.hideLoader();
        return;
    }

    const trek = {
        location: this.params.location,
        dateTime: this.params.dateTime,
        description: this.params.description,
        imageURL: this.params.imageURL,
        organizer: this.app.userData.username
    };

    try {
        notifications.showLoader();
        const editedTrek = await apiEditTrek(trek, this.params.id);

        if (editedTrek.code) {
            throw editedTrek;
        }

        notifications.hideLoader();
        notifications.showNotification('Trek edited successfully.', 'info');

        this.redirect('#/home');
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}

export async function deleteTrekGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    const currTrek = await getTrekById(this.params.id);
    if (currTrek.organizer !== this.app.userData.username) {
        notifications.showNotification('You cannot close trek which is not created by you.', 'error');
        notifications.hideLoader();
        return;
    }

    try {
        notifications.showLoader();

        const deletionTime = await apiDeleteTrek(this.params.id);

        if (deletionTime.code) {
            throw deletionTime;
        }

        notifications.hideLoader();
        notifications.showNotification('You closed the trek successfully.', 'info');
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

    let trek = {};

    try {
        notifications.showLoader();
        trek = await getTrekById(this.params.id);

        if (trek.code) {
            throw trek;
        }

        if (trek.organizer === this.app.userData.username) {
            trek.isOrganizer = true;
        } else {
            trek.isOrganizer = false;
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

    Object.assign(trek, this.app.userData);

    this.partial('./templates/treks/details.hbs', trek);
}

export async function likeTrekGet() {
    const token = validateToken(this);

    if (!token) {
        return;
    }

    let trek = {};

    try {
        notifications.showLoader();

        trek = await getTrekById(this.params.id);

        if (trek.code) {
            throw trek;
        }

        if (trek.ownerId === this.app.userData.userId) {
            throw new Error('You cannot like trek requested by you.');
        }

        const likedTrek = await likeTrek(trek, this.params.id);

        if (likedTrek.code) {
            throw likedTrek;
        }

        notifications.hideLoader();
        notifications.showNotification('You liked the trek successfully.', 'info');     
        this.redirect(`#/details/${this.params.id}`);
    } catch (error) {
        console.error(error);
        notifications.hideLoader();
        notifications.showNotification(error.message, 'error');
    }
}