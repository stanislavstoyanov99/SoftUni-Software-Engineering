function loadRepos() {
	const inputField = document.getElementById('username');
	const inputUsername = inputField.value;
	const url = `https://api.github.com/users/${inputUsername}/repos`;
	const reposList = document.getElementById('repos');

	reposList.textContent = '';

	fetch(url)
	  .then(res => res.json())
	  .then(data => data.forEach(currRepo => {		  
		  const repo = document.createElement('li');
		  const repoLink = document.createElement('a');

		  repoLink.textContent = currRepo.full_name;
		  repoLink.href = currRepo.html_url;
		  
		  repo.appendChild(repoLink);
		  reposList.appendChild(repo);

		  inputField.value = '';
	  }))
	  .catch(error => alert(error));
}