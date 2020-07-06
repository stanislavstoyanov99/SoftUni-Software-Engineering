function solve() {
    const elements = {
        infoSpan() { return document.querySelector('#info > .info') },
        depart() { return document.querySelector('input#depart') },
        arrive() { return document.querySelector('input#arrive') }
    };

    let busStopId = 'depot';
    let busStopName = '';
    const url = `https://judgetests.firebaseio.com/schedule/`;

    function depart() {
        elements.depart().setAttribute('disabled', true);
        elements.arrive().removeAttribute('disabled');

        fetch(url + `${busStopId}.json`)
            .then((response) => response.json())
            .then((response) => {
                elements.infoSpan().textContent = `Next stop ${response.name}`;
                busStopId = response.next;
                busStopName = response.name;
            });
    }

    function arrive() {
        elements.infoSpan().textContent = `Arriving at ${busStopName}`;
        
        elements.arrive().setAttribute('disabled', true);
        elements.depart().removeAttribute('disabled');
    }

    return {
        depart,
        arrive
    };
}

let result = solve();