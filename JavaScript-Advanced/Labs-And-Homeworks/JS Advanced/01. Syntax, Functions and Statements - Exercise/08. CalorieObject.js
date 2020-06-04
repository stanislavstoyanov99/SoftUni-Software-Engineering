function composeObject(params) {
    const calorieObject = {};

    for (let i = 0; i < params.length; i += 2) {
        const nameOfFood = params[i];
        const calories = Number(params[i + 1]);

        calorieObject[nameOfFood] = calories;
    }

    console.log(calorieObject);
}

composeObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);