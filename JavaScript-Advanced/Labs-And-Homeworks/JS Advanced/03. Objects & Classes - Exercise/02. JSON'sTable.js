function JSONToHTMLTable(jsonString) {
    const rows = [];

    for (const line of jsonString) {
        const person = JSON.parse(line);
        rows.push(createRow(person));
    }

    console.log('<table>');
    console.log(rows.join('\n'));
    console.log('</table>');

    function createRow(person) {
        return [
            '\t<tr>',
            `\t\t<td>${person.name}</td>`,
            `\t\t<td>${person.position}</td>`,
            `\t\t<td>${person.salary}</td>`,
            '\t</tr>'
        ].join('\n');
    }
}

JSONToHTMLTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']);