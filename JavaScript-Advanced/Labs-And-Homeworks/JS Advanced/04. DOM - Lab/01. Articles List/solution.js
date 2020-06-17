function createArticle() {
	const titleInput = document.getElementById('createTitle');
	const contentInput = document.getElementById('createContent');

	if (titleInput.value === '' || contentInput.value === '') {
		return;
	}

	const articles = document.getElementById('articles');
	const article = document.createElement('article');
	const heading = document.createElement('h3');
	const paragraph = document.createElement('p');

	heading.innerText = titleInput.value;
	paragraph.innerText = contentInput.value;

	article.appendChild(heading);
	article.appendChild(paragraph);
	articles.appendChild(article);

	titleInput.value = '';
	contentInput.value = '';
}