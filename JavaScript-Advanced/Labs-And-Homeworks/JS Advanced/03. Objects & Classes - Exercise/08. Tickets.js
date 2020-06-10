function manageTickets(inputArray, sortingCriterion) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const ticketsArray = [];

    for (const item of inputArray) {
        let [destinationName, price, status] = item.split('|');
        price = Number(price);

        const ticket = new Ticket(destinationName, price, status);
        ticketsArray.push(ticket);
    }

    const sortedTickets = ticketsArray.sort((a, b) => {
        if (sortingCriterion === 'destination') {
            return a.destination.localeCompare(b.destination);
        } else if (sortingCriterion === 'price') {
            return a.price - b.price;
        } else if (sortingCriterion === 'status') {
            return a.status.localeCompare(b.status);
        }
    });

    return sortedTickets;
}

console.log(manageTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
));

console.log(manageTickets(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'
));