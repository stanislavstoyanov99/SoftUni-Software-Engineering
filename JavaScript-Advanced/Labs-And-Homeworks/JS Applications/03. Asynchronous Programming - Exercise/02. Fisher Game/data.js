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
    const response = await fetch(host(api.getCatches));
    const data = await response.json();

    return data;
}

export async function createCatch(catchObj) {
    await fetch(host(api.createCatch), {
        method: 'POST',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(catchObj)
    });

    return true;
}

export async function updateCatch(id, catchObj) {
    const response = await fetch(host(`${api.updateCatch + id}`), {
        method: 'PUT',
        headers: {'Content-type': 'application/json'},
        body: JSON.stringify(catchObj)
    });

    const updatedCatch = await response.json();

    return updatedCatch;
}

export async function deleteCatch(id) {
    await fetch(host(`/${api.deleteCatch + id}`), {
        method: 'DELETE'
    });

    return true;
}