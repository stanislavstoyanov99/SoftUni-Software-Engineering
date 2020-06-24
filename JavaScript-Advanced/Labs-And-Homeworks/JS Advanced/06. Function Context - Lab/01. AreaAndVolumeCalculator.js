function area() {
    return this.x * this.y;
}

function vol() {
    return this.x * this.y * this.z;
}

function solve(area, vol, inputJSON) {
    const inputData = JSON.parse(inputJSON);

    let resultObj = inputData.map(obj => {
        const objArea = Math.abs(area.call(obj));
        const objVolume = Math.abs(vol.call(obj));
        
        return {
            area: objArea,
            volume: objVolume
        };
    });

    return resultObj;
}

const inputJSON = '[ {"x":"1","y":"2","z":"10"}, {"x":"7","y":"7","z":"10"}, {"x":"5","y":"2","z":"10"} ]';

console.log(solve(area, vol, inputJSON));