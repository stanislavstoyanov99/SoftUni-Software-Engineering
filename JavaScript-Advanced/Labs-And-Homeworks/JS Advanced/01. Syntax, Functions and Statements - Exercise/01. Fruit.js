function buyFruit(fruitType, weightInGrams, pricePerKg) {
    const weightInKg = Number(weightInGrams) / 1000;
    const neededMoney = weightInKg * Number(pricePerKg);
    return `I need $${neededMoney.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruitType}.`;
}

console.log(buyFruit('orange', 2500, 1.80));
console.log(buyFruit('apple', 1563, 2.35));