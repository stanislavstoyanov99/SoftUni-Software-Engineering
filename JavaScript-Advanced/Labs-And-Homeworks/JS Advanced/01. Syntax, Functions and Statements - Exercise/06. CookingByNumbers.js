function performOperations(input) {
    let number = Number(input[0]);
    let resultFromOperation = 0;

    for (let i = 1; i < input.length; i++) {
        let operation = input[i];

        switch (operation) {
            case 'chop':
                resultFromOperation = number / 2;
                break;
            case 'dice':
                resultFromOperation = Math.sqrt(number);
                break;
            case 'spice':
                resultFromOperation = number + 1;
                break;
            case 'bake':
                resultFromOperation = number * 3;
                break;
            case 'fillet':
                resultFromOperation = number * 0.8;
        }

        number = resultFromOperation;

        console.log(Number(resultFromOperation.toFixed(2)));
    }
}

performOperations(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);
performOperations(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);