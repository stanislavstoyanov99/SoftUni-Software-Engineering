function composeObject(inputJson) {
    const data = JSON.parse(inputJson);

    const resultObj = {};

    data.forEach(obj => {
        Object.entries(obj).forEach(([key, value]) => resultObj[key] = value);
    })

    return resultObj;
}

console.log(composeObject(`[{"canMove": true},{"canMove":true, "doors": 4},{"capacity": 5}]`));
console.log(composeObject(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`));