function createCars(inputData) {
    const operationsMap = {
        create: (acc, carName, _, inheritName) => {
            if (!inheritName) {
                acc[carName] = {};
                return acc;
            }

            // Make inheritance here with creatinon of prototype
            const parent = acc[inheritName];
            acc[carName] = Object.create(parent);

            return acc;
        },
        set: (acc, carName, propName, propValue) => {
            acc[carName][propName] = propValue;
            return acc;
        },
        print: (acc, carName) => {
            let result = [];

            for (let property in acc[carName]) {
                result.push(`${property}:${acc[carName][property]}`);
            }

            console.log(result.join(', '));

            return acc;
        }
    };

    return inputData.reduce((acc, currCommand) => {
        const [operation, carName, arg1, arg2] = currCommand.split(' ');
        return operationsMap[operation](acc, carName, arg1, arg2);
    }, {});
}

createCars(['create c1', 'create c2 inherit c1', 'set c1 color red', 'set c2 model new', 'print c1', 'print c2']);