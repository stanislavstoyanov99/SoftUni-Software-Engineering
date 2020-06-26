function solve() {
    return {
        extend(template) {
            for (const property in template) {
                if (typeof template[property] === 'function') {
                    const prototype = Object.getPrototypeOf(this);
                    prototype[property] = template[property];           
                }

                this[property] = template[property];
            }
        }
    }
}