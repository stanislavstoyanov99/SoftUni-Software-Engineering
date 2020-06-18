function solve() {
    const expression = document.getElementById('expressionOutput');
    const result = document.getElementById('resultOutput');

    const clearButton = document.querySelector('.clear');
    clearButton.addEventListener('click', () => {
        memory.firstOperand = '';
        memory.secondOperand = '';
        memory.operator = '';
        expression.textContent = '';
        result.textContent = '';
    })

    const memory = {
        firstOperand: '',
        secondOperand: '',
        operator: '',
    };

    const operations = {
        '+': () => Number(memory.firstOperand) + Number(memory.secondOperand),
        '-': () => Number(memory.firstOperand) - Number(memory.secondOperand),
        '*': () => Number(memory.firstOperand) * Number(memory.secondOperand),
        '/': () => Number(memory.firstOperand) / Number(memory.secondOperand),
        '=': true,
    };
    
    const [...buttons] = document.querySelector('.keys').querySelectorAll('button');
    buttons.forEach(b => b.addEventListener('click', onClick));

    function onClick(e) {
        const value = e.target.value;

        if (operations.hasOwnProperty(value)) {
            // operator is clicked (+, -, *, /, .)
            if (value === '=') {
                // Check for invalid first or second operand and return NaN
                if (memory.firstOperand === '' || memory.secondOperand === '') {
                    result.textContent = 'NaN';
                } else {
                    result.textContent = operations[memory.operator]();
                }
            } else {
                memory.operator = value;
            }
        } else {
            // number is clicked
            if (memory.operator === '') {
                memory.firstOperand += value;
            } else {
                memory.secondOperand += value;
            }
        }

        // Combine first operand, operator and second operand
        expression.textContent = `${memory.firstOperand} ${memory.operator} ${memory.secondOperand}`;
    }
}