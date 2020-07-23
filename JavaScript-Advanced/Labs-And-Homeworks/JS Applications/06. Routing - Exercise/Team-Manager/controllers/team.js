import { getTeamById, editTeam } from '../scripts/data.js';
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
        team = await getTeamById(this.params.id, token);

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
        const editedTeam = await editTeam(team, this.params.id, token);

        if (editedTeam.code) {
            throw editedTeam;
        }

        notifications.showNotification('Team edited!', 'info');

        this.redirect(`#/catalog/${editedTeam.objectId}`);
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}
