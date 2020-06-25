function listProcessor(inputData) {
    let container = [];

    const operations = {
        add: (item) => container.push(item),
        remove: (item) => container = container.filter(i => i !== item),
        print: () => console.log(container.join(','))
    };

    inputData.forEach(item => {
        const [operation, token] = item.split(' ');
        operations[operation](token);
    });
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);