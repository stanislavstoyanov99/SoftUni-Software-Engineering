function solve() {
   const searchBtn = document.getElementById('searchBtn');

   let selectedRows = [];

   searchBtn.addEventListener('click', () => {
      if (selectedRows) {
         selectedRows.forEach(row => row.parentElement.classList.remove('select'));
      }

      const tableData = document.querySelectorAll('.container tbody td');
      const inputField = document.getElementById('searchField');
      const inputValue = inputField.value.trim();

      if (inputValue.length > 0) {
         for (let row = 0; row < tableData.length; row++) {
            const currentRow = tableData[row];
   
            if (currentRow.textContent.trim().includes(inputValue)) {
               selectedRows.push(currentRow);
               currentRow.parentElement.classList.add('select');
            }
         }
         
         inputField.value = '';
      }
   });
}