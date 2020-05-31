function buyFruit(fruitType, weight, pricePerKg) {
    let weightInKg = (Number(weight) / 1000);
    let neededMoney = weightInKg * Number(pricePerKg);
    return `I need $${neededMoney.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruitType}.`;
}

console.log(buyFruit('orange', 2500, 1.80));
console.log(buyFruit('apple', 1563, 2.35));