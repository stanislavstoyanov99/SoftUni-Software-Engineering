function solve() {
    document.getElementById('dropdown').addEventListener('click', showOptions);
    document.getElementById('dropdown-ul').addEventListener('click', changeColor);

    const box = document.getElementById('box');

    function showOptions() {
        const menu = document.getElementById('dropdown-ul');
        
        if (menu.style.display === 'block') {
            menu.style.display = 'none';
            box.style.backgroundColor = 'black';
            box.style.color = 'white';
        } else {
            menu.style.display = 'block';
        }
    }

    function changeColor(e) {
        const color = e.target.textContent;
        box.style.backgroundColor = color;
        box.style.color = 'black';
    }
}