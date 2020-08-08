export default function(app) {
    const errors = [];

    if (!app.params.title ||
        !app.params.description ||
        !app.params.imageUrl) {
        errors.push('Invalid inputs!');
    }
    
    return errors;
}