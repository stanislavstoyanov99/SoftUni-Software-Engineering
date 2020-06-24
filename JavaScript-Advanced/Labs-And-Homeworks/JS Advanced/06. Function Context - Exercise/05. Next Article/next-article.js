function getArticleGenerator(articles) {
    const divContent = document.getElementById('content');

    return appendArticle;
    
    function appendArticle() {
        const currArticle = articles.shift();

        if (currArticle) {
            const article = document.createElement('article');
            article.textContent = currArticle;
            divContent.appendChild(article);
        }
    }
}