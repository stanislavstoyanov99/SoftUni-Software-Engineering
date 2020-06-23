function solve() {
   const searchBtn = document.getElementById('searchBtn');

   const tableData = document.querySelectorAll('.container tbody td');

   let selectedRows = [];

   searchBtn.addEventListener('click', () => {
      if (selectedRows) {
         selectedRows.forEach(row => row.parentElement.classList.remove('select'));
      }

      const inputField = document.getElementById('searchField');

      for (let row = 0; row < tableData.length; row++) {
         const currentRow = tableData[row];

         if (currentRow.textContent.includes(inputField.value)) {
            selectedRows.push(currentRow);
            currentRow.parentElement.classList.add('select');
         }
      }
      
      inputField.value = '';
   });
}