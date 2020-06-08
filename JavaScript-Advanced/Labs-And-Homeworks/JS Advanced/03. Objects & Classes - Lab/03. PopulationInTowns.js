function registerTownsWithPopulation(inputArray) {
    const townObj = {};

    for (let i = 0; i < inputArray.length; i++) {
        const inputData = inputArray[i].split(' <-> ');

        const town = inputData[0];
        const populationSize = Number(inputData[1]);

        if (!Object.keys(townObj).includes(town)) {
            townObj[town] = populationSize;
        } else {
            townObj[town] += populationSize;
        }
    }

    for (const item in townObj) {
        console.log(`${item} : ${townObj[item]}`);
    }        
    
    // Second way to print object data
    // Object.entries(obj).forEach(
    //     ([key, value]) => console.log(`${key} : ${value}`));
}

registerTownsWithPopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);