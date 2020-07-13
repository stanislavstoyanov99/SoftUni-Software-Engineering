(async function fetchData() {
    const elements = {
        getTableBody() { return document.querySelector('#results > tbody') }
    };

    const baseUrl = 'https://softunihomework-f0671.firebaseio.com/Students.json';

    async function loadStudents() {
        const response = await fetch(baseUrl);
        const students = await response.json();

        students
            .forEach((student, id) => {

                if (id > 0) {
                    const tr = document.createElement('tr');

                    tr.innerHTML =
                        `<tr>
                            <th>${id}</th>
                            <th>${student.firstName}</th>
                            <th>${student.lastName}</th>
                            <th>${student.facultyNumber}</th>
                            <th>${student.grade}</th>
                            </tr>`;
    
                    elements.getTableBody().appendChild(tr);
                }
            });
    }

    await loadStudents();
})();