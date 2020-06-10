class List {
    constructor() {
        this._values = [];
        this.size = this._values.length;
    }

    add(element) {
        this._values.push(element);
        this._values.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (index < 0 || index >= this._values.length) {
            throw new Error('The requested element cannot be found.');
        }

        this._values.splice(index, 1);
        this.size--;
    }

    get(index) {
        if (index < 0 || index >= this._values.length) {
            throw new Error('The requested element cannot be found.');
        }
        
        return this._values[index];
    }
}

let list = new List();
list.remove(0);