export default function(app) {
    const errors = [];

    if (!app.params.location ||
        !app.params.dateTime ||
        !app.params.description ||
        !app.params.imageURL) {
        errors.push('All input fields are required.');
    }

    if (app.params.location.length < 6) {
        errors.push('The location name should be at least 6 characters long.');
    }

    if (app.params.description.length < 10) {
        errors.push('The description should be at least 10 characters long.');
    }

    if (!app.params.imageURL.startsWith('https://') && !app.params.imageURL.startsWith('http://')) {
        errors.push('The image should start with "https://" or "http://".');
    }

    return errors;
}