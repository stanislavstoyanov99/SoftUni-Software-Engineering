function findLowestPriceOfProducts(inputArray) {
    const map = new Map();

    for (let i = 0; i < inputArray.length; i++) {
        const inputData = inputArray[i].split(' | ');

        const town = inputData[0];
        const product = inputData[1];
        const productPrice = Number(inputData[2]);

        if (!map.has(product)) {
            map.set(product, new Map());
        }

        map.get(product).set(town, Number(productPrice));
    }

    for (let [product, innerMap] of map) {
        let productLowestPrice = Number.POSITIVE_INFINITY;
        let townWithLowestPrice = '';

        for (let [town, price] of innerMap) {
            if (price < productLowestPrice) {
                productLowestPrice = price;
                townWithLowestPrice = town;
            }
        }

        console.log(`${product} -> ${productLowestPrice} (${townWithLowestPrice})`);
    }
}

findLowestPriceOfProducts(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
)