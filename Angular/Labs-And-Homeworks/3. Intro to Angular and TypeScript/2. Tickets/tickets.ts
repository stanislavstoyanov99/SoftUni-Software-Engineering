class Ticket {
    private destination: string;
    private price: number;
    private status: string;

    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }

    getDestination(): string {
        return this.destination;
    }

    getPrice(): number {
        return this.price;
    }

    getStatus(): string {
        return this.status;
    }
}

function manageTickets(inputData: string[], sortingCriteria: string): Ticket[] {    
    let ticketsArray: Ticket[] = [];

    inputData.forEach(item => {
        let [destinationName, price, status] = item.split('|');

        let ticket = new Ticket(destinationName, Number(price), status);
        ticketsArray.push(ticket);
    });

    let sortedTickets = ticketsArray.sort((a, b) => {
        switch (sortingCriteria) {
            case "destination":
                return a.getDestination().localeCompare(b.getDestination());
            case "price":
                return a.getPrice() - b.getPrice();
            case "status":
                return a.getStatus().localeCompare(b.getStatus());
            default:
                return 0;
        }
    });

    return sortedTickets;
}

console.log(manageTickets([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'],
    'destination'
));

console.log(manageTickets([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'],
    'status'
));