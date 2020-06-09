function storeCatalogue(inputData) {
    const catalogue = {};

    for (const item of inputData) {
        let [productName, productPrice] = item.split(' : ');

        productPrice = Number(productPrice);
        catalogue[productName] = productPrice;
    }

    const sortedProducts = Object.keys(catalogue)
        .sort((a, b) => a.localeCompare(b) || catalogue[a] - catalogue[b]);

    let currInitialLetter = '';

    for (const productName of sortedProducts) {
        if (productName[0] !== currInitialLetter) {
            currInitialLetter = productName[0];
            console.log(currInitialLetter);
        }

        console.log(`  ${productName}: ${catalogue[productName]}`);
    }
}

storeCatalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);