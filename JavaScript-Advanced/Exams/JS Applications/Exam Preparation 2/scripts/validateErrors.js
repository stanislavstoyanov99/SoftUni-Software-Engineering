export default function(app) {
    const errors = [];

    if (!app.params.meal ||
        !app.params.ingredients ||
        !app.params.prepMethod ||
        !app.params.description ||
        !app.params.foodImageURL ||
        !app.params.category) {
        errors.push('All input fields are required.');
    }

    if (app.params.meal.length < 4) {
        errors.push('The meal name should be at least 4 characters long.');
    }

    if (app.params.ingredients.length < 2) {
        errors.push('The ingredients should be at least 2.');
    }

    if (app.params.prepMethod.length < 10) {
        errors.push('The preparation method should be at least 10 characters long.');
    }

    if (app.params.description.length < 10) {
        errors.push('The description should be at least 10 characters long.');
    }

    if (!app.params.foodImageURL.startsWith('https://') && !app.params.foodImageURL.startsWith('http://')) {
        errors.push('The food image should start with "https://" or "http://".');
    }

    if (app.params.category === 'Select category...') {
        errors.push('Please select category from the list.');
    }

    return errors;
}