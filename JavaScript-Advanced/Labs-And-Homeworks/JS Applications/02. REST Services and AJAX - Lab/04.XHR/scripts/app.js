function loadRepos() {
   const url = 'https://api.github.com/users/testnakov/repos';
   const httpRequest = new XMLHttpRequest();
   const resultDiv = document.getElementById('res');

   httpRequest.addEventListener('readystatechange', () => {
      if (httpRequest.readyState == 4 && httpRequest.status == 200) {
         resultDiv.textContent = httpRequest.responseText;
      }
   });

   httpRequest.open('GET', url);
   httpRequest.send();
}