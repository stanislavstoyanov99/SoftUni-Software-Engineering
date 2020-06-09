function createBottle(inputData) {
    const juiceObj = {};
    const bottlesObj = {};

    for (const item of inputData) {
        let [juiceName, juiceQuantity] = item.split(' => ');
        juiceQuantity = Number(juiceQuantity);

        if (!Object.keys(juiceObj).includes(juiceName)) {
            juiceObj[juiceName] = juiceQuantity;
        } else {
            juiceObj[juiceName] += juiceQuantity;
        }

        let currJuiceQuantity = juiceObj[juiceName];
        if (currJuiceQuantity >= 1000) {
            const juiceLeft = currJuiceQuantity % 1000;
            const bottlesCount = (currJuiceQuantity - juiceLeft) / 1000;

            !bottlesObj.hasOwnProperty(juiceName) ?
                 bottlesObj[juiceName] = bottlesCount : bottlesObj[juiceName] += bottlesCount;

            juiceObj[juiceName] = juiceLeft;
        }
    }

    const bottles = Object.entries(bottlesObj);

    for (const [juiceName, bottleCount] of bottles) {
        console.log(`${juiceName} => ${bottleCount}`);
    }
}

createBottle(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);