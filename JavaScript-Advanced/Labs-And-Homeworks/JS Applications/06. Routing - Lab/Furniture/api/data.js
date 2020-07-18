const baseUrl = 'https://api.backendless.com/7AB8E746-DB03-607F-FF01-EE7CAB313300/DFC57F59-2D6D-4E86-9C5B-61EAF81ECA77/data/Furniture';

export async function createFurniture(furniture) {
    return await (await fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(furniture)      
    })).json();
}

export async function getAllFurniture() {
    return await (await fetch(baseUrl)).json();
}

export async function getFurnitureById(id) {
    return await (await fetch(baseUrl + `/${id}`)).json();
}

export async function deleteFurniture(id) {
    return await (await fetch(url + `/${id}`, {
        method: 'DELETE',
    })).json();
}