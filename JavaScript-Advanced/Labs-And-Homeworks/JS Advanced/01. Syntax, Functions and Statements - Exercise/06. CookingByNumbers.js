function performOperations(input) {
    let number = Number(input[0]);
    for (let i = 1; i < input.length; i++) {
        let operation = input[i];

        switch (operation) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
        }

        console.log(Number(number.toFixed(2)));
    }
}

performOperations(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);
performOperations(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);