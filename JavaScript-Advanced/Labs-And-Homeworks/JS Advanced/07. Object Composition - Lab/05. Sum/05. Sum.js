function manipulateDom() {
    let firstNum, secondNum, result;

    const dom = {
        init,
        add,
        subtract
    };

    return dom;

    function init(firstSelector, secondSelector, resultSelector) {
        firstNum = document.querySelector(firstSelector);
        secondNum = document.querySelector(secondSelector);
        result = document.querySelector(resultSelector);
    }

    function add() {
        result.value = Number(firstNum.value) + Number(secondNum.value);
    }

    function subtract() {
        result.value = Number(firstNum.value) - Number(secondNum.value);
    }
}

const sumBtn = document.getElementById('sumButton');
const subBtn = document.getElementById('subtractButton');

let solve = manipulateDom();
solve.init('#num1', '#num2', '#result');

sumBtn.addEventListener('click', () => {
    solve.add();
});

subBtn.addEventListener('click', () => {
    solve.subtract();
});