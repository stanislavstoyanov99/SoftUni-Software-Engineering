function growingWord() {
  const word = document.querySelector('#exercise > p');

  if (!word.hasAttribute("style")) {
    word.style.color = "blue";
    word.style.fontSize = "2px";
    return;
  }

  const currColor = word.style.color;
  let currFontSize = word.style.fontSize;
  currFontSize = Number(currFontSize.slice(0, currFontSize.length - 2)) * 2;

  let colorChanges = {
    "blue": "green",
    "green": "red",
    "red": "blue"
  };

  word.style.color = colorChanges[currColor];
  word.style.fontSize = currFontSize + "px";
}