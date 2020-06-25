function assembleCar(inputCar) {
    const engineMap = {
        90: { power: 90, volume: 1800 },
        120: { power: 120, volume: 2400 },
        200: { power: 200, volume: 3500 }
    };

    let assembledCar = {
        model: inputCar.model,
        engine: setEngine(inputCar.power),
        carriage: {
            type: inputCar.carriage,
            color: inputCar.color
        },
        wheels: setWheels(inputCar.wheelsize)
    };

    return assembledCar;

    function setEngine(power) {
        let engine = {};

        if (power <= 90) {
            engine = engineMap[90];
        } else if (power > 90 && power <= 120) {
            engine = engineMap[120];
        } else if (power > 120 && power <= 200) {
            engine = engineMap[200];
        }

        return engine;
    }

    function setWheels(wheelsize) {
        let wheels = [];

        for (let i = 0; i < 4; i++) {
            if (wheelsize % 2 === 0) {
                // round down to the nearest odd integer
                const modifiedWheelSize = 2 * Math.floor(wheelsize / 2) - 1;
                wheels.push(modifiedWheelSize);
            }
            else {
                wheels.push(wheelsize);
            }
        }

        return wheels;
    }
}

console.log(assembleCar(
    {
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }));