import * as data from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export async function editTeamGet() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }

    let team = {};

    try {
        team = await data.getTeamById(this.params.id, token);

        if (team.code) {
            throw team;
        }
    } catch (error) {
        notifications.showNotification(error.message, 'error');
        return;
    }

    this.partials = {
        header: (await this.load('./templates/common/header.hbs')),
        footer: (await this.load('./templates/common/footer.hbs')),
        editForm: (await this.load('./templates/edit/editForm.hbs'))
    };

    Object.assign(team, this.app.userData);

    this.partial('./templates/edit/editPage.hbs', team);
}

export async function editTeamPost() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/login');
        return;
    }

    if (!this.params.name) {
        notifications.showNotification('Team name is required', 'error');
        return;
    }

    const team = {
        name: this.params.name,
        comment: this.params.comment
    };

    try {
        const editedTeam = await data.editTeam(team, this.params.id, token);

        if (editedTeam.code) {
            throw editedTeam;
        }

        notifications.showNotification('Team edited', 'info');

        this.redirect(`#/catalog/${editedTeam.objectId}`);
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}

export async function joinTeam() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }

    if (this.app.userData.hasTeam) {
        notifications.showNotification('You already have a team', 'error');
        this.redirect('#/catalog');
        return;
    }

    try {
        const updatedUser = await data.joinTeam(this.params.id, localStorage.userId, token);

        if (updatedUser.code) {
            throw editedTeam;
        }

        this.app.userData.hasTeam = true;
        this.app.userData.teamId = this.params.id;
        notifications.showNotification('You have joined the team', 'info');
        this.redirect('#/catalog');
    } catch (error) {
        notifications.showNotification(error.message, 'error');
    }
}

export async function leaveTeam() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }

    try {
        const updatedUser = await data.leaveTeam(localStorage.userId, token);

        if (updatedUser.code) {
            throw editedTeam;
        }

        this.app.userData.hasTeam = false;
        this.app.userData.teamId = undefined;
        notifications.showNotification('You have left the team', 'info');
        this.redirect('#/catalog');
    } catch (error) {
        notifications.showNotification(error.message, 'error');
    }
}
