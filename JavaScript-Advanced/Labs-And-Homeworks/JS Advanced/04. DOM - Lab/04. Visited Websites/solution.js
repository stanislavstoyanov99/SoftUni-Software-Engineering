function solve() {
  const middledDivArray = Array.from(document.querySelectorAll('.middled div'));

  for (let i = 0; i < middledDivArray.length; i++) {
    const element = middledDivArray[i];
    element.id = `link_${i}`;
    const link = element.children[0];

    link.addEventListener('click', () => {
      const paragraph = document.getElementById(`${element.id}`).lastElementChild;
      let count = Number(paragraph.innerText.match(/\d+/));
      paragraph.innerText = paragraph.innerText.replace(/\d+/, ++count);
    });
  }
}