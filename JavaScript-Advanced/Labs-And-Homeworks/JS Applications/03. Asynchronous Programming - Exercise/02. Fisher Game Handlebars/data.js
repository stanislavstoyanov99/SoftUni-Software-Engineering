function host(endpoint) {
    return `https://fisher-game.firebaseio.com/${endpoint}.json`;
}

const api = {
    getCatches: 'catches',
    createCatch: 'catches',
    updateCatch: 'catches/',
    deleteCatch: 'catches/'
};

export async function getCatches() {
    const catches = await (await fetch(host(api.getCatches))).json();
    return Object.entries(catches).map(([key, value]) => Object.assign({}, value, { _id: key }));
}

export async function createCatch(catchObj) {
    return (await fetch(host(api.createCatch), {
        method: 'POST',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(catchObj)
    })).json();
}

export async function updateCatch(id, catchObj) {
    return (await fetch(host(`${api.updateCatch + id}`), {
        method: 'PUT',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(catchObj)
    })).json();
}

export async function deleteCatch(id) {
    return (await fetch(host(`${api.deleteCatch + id}`), {
        method: 'DELETE'
    }));
}