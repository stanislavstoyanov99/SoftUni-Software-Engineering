function host(endpoint) {
    return `https://softunihomework-f0671.firebaseio.com/${endpoint}.json`;
}

const api = {
    students: 'Students'
};

export async function getStudents() {
    const response = await fetch(host(api.students));
    const students = await response.json();

    return students;
}

export async function createStudent(student) {
    const createdStudent = await fetch(host(api.students), {
        method: 'POST',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(student)
    });

    return createdStudent;
}