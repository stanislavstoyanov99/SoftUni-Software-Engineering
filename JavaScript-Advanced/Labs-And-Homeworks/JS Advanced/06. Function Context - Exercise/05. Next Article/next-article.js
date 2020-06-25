// Example usage of closure
function getArticleGenerator(articles) {
    const divContent = document.getElementById('content');

    return showNext;
    
    function showNext() {
        const currArticle = articles.shift();

        if (currArticle) {
            const article = document.createElement('article');
            article.textContent = currArticle;
            divContent.appendChild(article);
        }
    }
}