function solve() {
  const furnitureList = document.querySelectorAll('#exercise textarea')[0];
  const resultTextArea = document.querySelectorAll('#exercise textarea')[1];
  const generateBtn = document.querySelectorAll('#exercise button')[0];
  const buyBtn = document.querySelectorAll('#exercise button')[1];

  generateBtn.addEventListener('click', onGenerateClick);
  buyBtn.addEventListener('click', onBuyingClick);

  function onGenerateClick() {
    const furniture = JSON.parse(furnitureList.value);
    const tableBody = document.querySelector('.table tbody');

    [...furniture].forEach(item => {
      const tableRow = document.createElement('tr');

      const tableDataImg = document.createElement('td');
      const itemImage = document.createElement('img');
      itemImage.src = item.img;
      tableDataImg.appendChild(itemImage);
      tableRow.appendChild(tableDataImg);

      const tableDataName = document.createElement('td');
      const itemName = document.createElement('p');
      itemName.textContent = item.name;
      tableDataName.appendChild(itemName);
      tableRow.appendChild(tableDataName);

      const tableDataPrice = document.createElement('td');
      const itemPrice = document.createElement('p');
      itemPrice.textContent = item.price;
      tableDataPrice.appendChild(itemPrice);
      tableRow.appendChild(tableDataPrice);

      const tableDataDecFactor = document.createElement('td');
      const itemDecFactor = document.createElement('p');
      itemDecFactor.textContent = item.decFactor;
      tableDataDecFactor.appendChild(itemDecFactor);
      tableRow.appendChild(tableDataDecFactor);

      const tableDataMark = document.createElement('td');
      const inputDataMark = document.createElement('input');
      inputDataMark.setAttribute('type', 'checkbox');
      tableDataMark.appendChild(inputDataMark);
      tableRow.appendChild(tableDataMark);

      tableBody.appendChild(tableRow);
    });

    furnitureList.value = '';
  }

  function onBuyingClick() {
    const markedFurniture = [...document.querySelectorAll('input[type=checkbox]:checked')];
    let totalPrice = 0;
    let decFactor = 0;
    let boughtFurniture = [];

    markedFurniture.forEach(furniture => {
      const furnitureTd = furniture.parentNode;
      const furnitureRow = furnitureTd.parentNode;
      const selectorQuery = furnitureRow.querySelectorAll('td p');

      const furnitureName = selectorQuery[0].textContent;
      const furniturePrice = Number(selectorQuery[1].textContent);
      const furnitureDecFactor = Number(selectorQuery[2].textContent);

      boughtFurniture.push(furnitureName);
      totalPrice += furniturePrice;
      decFactor += furnitureDecFactor;  
    });

    const averageDecFactor = decFactor / markedFurniture.length;

    resultTextArea.value = `Bought furniture: ${boughtFurniture.join(', ')}` + 
    `\nTotal price: ${totalPrice.toFixed(2)}` + 
    `\nAverage decoration factor: ${averageDecFactor}`;
  }
}