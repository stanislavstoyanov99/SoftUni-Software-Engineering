export default async function() {
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs')
    };

    const data = Object.assign({}, this.app.userData);
    data.teams = [
        {
            teamId: 12345,
            name: 'Cherry',
            comment: 'Some comment'
        },
        {
            teamId: 123456,
            name: 'Apple',
            comment: 'Some comment 2'
        },
        {
            teamId: 123,
            name: 'Banana',
        },
    ];

    this.partial('./templates/catalog/teamCatalog.hbs', data);
}