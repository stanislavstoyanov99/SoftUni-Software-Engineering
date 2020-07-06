function getInfo() {
    const elements = {
        stopId() { return document.getElementById('stopId') },
        stopName() { return document.getElementById('stopName') },
        buses() { return document.getElementById('buses') }
    };

    const validIds = ['1287', '1308', '1327', '2334'];
    const stopId = elements.stopId().value;

    if (!validIds.includes(stopId)) {
        elements.buses().textContent = '';
        elements.stopName().textContent = 'Error';
        
        return;
    }

    const url = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;

    fetch(url)
      .then((response) => response.json())
      .then((data) => showInfo(data));
    
    function showInfo(data) {
        elements.buses().textContent = '';
        elements.stopName().textContent = data.name;
        const buses = Object.keys(data.buses);

        buses.forEach((bus) => {
            const listItem = document.createElement('li');
            listItem.textContent = `Bus ${bus} arrives in ${data.buses[bus]}`;
            elements.buses().appendChild(listItem);

            elements.stopId().value = '';
        });
    }
}