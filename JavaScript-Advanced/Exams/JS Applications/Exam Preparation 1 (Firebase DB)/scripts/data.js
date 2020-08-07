export async function apiCreateEvent(data) {
    return await firebase.firestore().collection('events').add(data);
}

export async function getAllEvents() {
    return await firebase.firestore().collection('events').get();
}

export async function getEventById(id) {
    return await firebase.firestore().collection('events').doc(id).get();
}

export async function apiDeleteEvent(id) {
    return await firebase.firestore().collection('events').doc(id).delete();
}

export async function apiEditEvent(data, id) {
    return await firebase.firestore().collection('events').doc(id).update(data);
}

export async function apiJoinEvent(id) {
    const event = await getEventById(id);
    const joinedEvent = event.data();
    joinedEvent.people++;

    return await apiEditEvent(joinedEvent, id);
}

export async function register(username, password) {
    return await firebase.auth().createUserWithEmailAndPassword(username, password);
}

export async function login(username, password) {
    return await firebase.auth().signInWithEmailAndPassword(username, password);
}

export async function logout() {
    return await firebase.auth().signOut();
}

export async function getEventsByOrganizer(organizer) {
    const response = await getAllEvents();
    return response.docs
        .map(x => x = { ...x.data()})
        .filter(x => x.organizer == organizer);
}