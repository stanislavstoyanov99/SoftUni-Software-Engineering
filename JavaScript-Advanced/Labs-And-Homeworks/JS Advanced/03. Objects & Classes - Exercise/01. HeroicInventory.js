function createRegister(inputArray) {
    const resultArray = [];

    for (const item of inputArray) {
        let [name, level, items] = item.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        const hereObj = { name, level, items };
        resultArray.push(hereObj);
    }

    return JSON.stringify(resultArray);
}

console.log(createRegister(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']
));