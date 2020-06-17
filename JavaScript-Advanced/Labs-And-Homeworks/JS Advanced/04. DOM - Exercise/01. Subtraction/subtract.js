function subtract() {
    const firstNumberInput = document.getElementById('firstNumber');
    const secondNumberInput = document.getElementById('secondNumber');

    const firstNumber = Number(firstNumberInput.value);
    const secondNumber = Number(secondNumberInput.value);

    const result = firstNumber - secondNumber;
    const resultDiv = document.querySelector('#result');
    resultDiv.innerText = result.toString();
}