var Ticket = /** @class */ (function () {
    function Ticket(destination, price, status) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
    Ticket.prototype.getDestination = function () {
        return this.destination;
    };
    Ticket.prototype.getPrice = function () {
        return this.price;
    };
    Ticket.prototype.getStatus = function () {
        return this.status;
    };
    return Ticket;
}());
function manageTickets(inputData, sortingCriteria) {
    var ticketsArray = [];
    inputData.forEach(function (item) {
        var _a = item.split('|'), destinationName = _a[0], price = _a[1], status = _a[2];
        var ticket = new Ticket(destinationName, Number(price), status);
        ticketsArray.push(ticket);
    });
    var sortedTickets = ticketsArray.sort(function (a, b) {
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
    'Boston|126.20|departed'
], 'destination'));
console.log(manageTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'status'));
