function sortedList() {
    const collection = [];
    let size = 0;

    function add(element) {
        collection.push(element);
        this.size++;
        return sortList();
    }

    function remove(index) {
        validateIndex(index);
        collection.splice(index, 1);
        this.size--;
        return sortList();
    }

    function get(index) {
        validateIndex(index);
        return collection[index];
    }

    function validateIndex(index) {
        if (index < 0 || index >= collection.length) {
            throw new Error('Index out of range!');
        }
    }

    function sortList() {
        collection.sort((a, b) => a - b);
    }

    return { add, remove, get, size };
}

const list = sortedList();
list.add(5);
list.add(6);
list.remove(1);
console.log(list.get(0));
console.log(list.size);