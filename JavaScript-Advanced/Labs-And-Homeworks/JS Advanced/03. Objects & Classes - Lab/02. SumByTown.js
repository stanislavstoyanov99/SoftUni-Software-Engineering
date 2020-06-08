function sumByTown(inputArray) {
    const townObj = {};

    for (let i = 0; i < inputArray.length; i+=2) {
        const town = inputArray[i];
        const income = Number(inputArray[i + 1]);

        if (!Object.keys(townObj).includes(town)) {
            townObj[town] = income;
        } else {
            townObj[town] += income;
        }
    }

    return JSON.stringify(townObj);
}

console.log(sumByTown(['Sofia','20','Varna','3','Sofia','5','Varna','4']));