function createRegister(inputArray) {
    const carsMap = new Map();

    for (const item of inputArray) {
        let [carBrand, carModel, producedCars] = item.split(' | ');

        producedCars = Number(producedCars);

        if (!carsMap.has(carBrand)) {
            carsMap.set(carBrand, new Map());
        }

        if (carsMap.get(carBrand).has(carModel)) {
            let currProducedCars = carsMap.get(carBrand).get(carModel);
            currProducedCars += producedCars;

            carsMap.get(carBrand).set(carModel, currProducedCars);
        } else {
            carsMap.get(carBrand).set(carModel, producedCars);
        }
    }

    for (let [carBrand, innerMap] of carsMap) {
        console.log(`${carBrand}`);

        for (let [carModel, producedCars] of innerMap) {
            console.log(`###${carModel} -> ${producedCars}`);
        }
    }
}

createRegister(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);