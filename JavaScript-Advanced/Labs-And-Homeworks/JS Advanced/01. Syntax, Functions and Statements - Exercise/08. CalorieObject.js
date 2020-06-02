function composeObject(inputArray) {
    let data = inputArray
        .toString()
        .split(',');
    
    let composedObject = {};
    let nameOfFood;
    let calories;

    for (let i = 0; i < data.length; i++) {
        if (i % 2 === 0) {
            nameOfFood = data[i];                    
        }
        else {
            calories = Number(data[i]);
        }

        composedObject[nameOfFood] = calories;
    }

    console.log(composedObject);
}

composeObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
composeObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);