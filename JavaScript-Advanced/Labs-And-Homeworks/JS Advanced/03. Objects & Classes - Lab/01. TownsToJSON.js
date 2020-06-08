function townsToJSON(inputArray) {
    let objArray = [];

    for (let i = 1; i < inputArray.length; i++) {
        let [town, latitude, longitude] = inputArray[i].split(' |');

        town = town.split('| ')[1];
        latitude = Number(Number(latitude.trim()).toFixed(2));
        longitude = Number(Number(longitude.trim()).toFixed(2));

        const obj = {Town: town, Latitude: latitude, Longitude: longitude};

        objArray.push(obj);
    }

    return JSON.stringify(objArray);
}

console.log(townsToJSON(['| Town | Latitude | Longitude |',
     '| Sofia | 42.696552 | 23.32601 |',
     '| Beijing | 39.913818 | 116.363625 |']))