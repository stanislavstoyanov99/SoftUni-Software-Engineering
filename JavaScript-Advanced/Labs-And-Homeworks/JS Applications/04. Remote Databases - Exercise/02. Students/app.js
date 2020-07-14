import * as data from './data.js';
import createElement from './dom.js';

window.addEventListener('load', async () => {
    const elements = {
        getTableBody() { return document.querySelector('#results > tbody') }
    };

    async function loadStudents() {
        elements.getTableBody().innerHTML = '<tr><td colspan="5">Loading...</td><tr>';

        try {
            const students = await data.getStudents();
            elements.getTableBody().innerHTML = '';

            students.sort((a, b) => {
                // Make this check because first element in the array is null because of Firebase sadly
                if (a) {
                    return b.grade - a.grade;
                }
            });
            
            students.forEach((student, id) => {

                // Check if id is number (>0) because of unexpected behaviour in Firebase with number id-s
                if (id > 0) {
                    const studentEl = createStudentEl(student, id);
                    elements.getTableBody().appendChild(studentEl);
                }
            });
        } catch (error) {
            alert(`Error: ${error.message}`);
        }
    }

    function createStudentEl(student, id) {
        return createElement('tr', [
            createElement('td', id),
            createElement('td', student.firstName),
            createElement('td', student.lastName),
            createElement('td', student.facultyNumber),
            createElement('td', student.grade.toFixed(2)),
        ]);
    }

    await loadStudents();
});