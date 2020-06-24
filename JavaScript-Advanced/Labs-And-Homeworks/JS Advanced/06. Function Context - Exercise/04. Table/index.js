function solve() {
   const tableBody = document.querySelector('.minimalistBlack > tbody');

   let selectedRow;
   
   tableBody.addEventListener('click', (e) => {
      if (e.target.nodeName === 'TD') {
         const target = e.target;

         if (target.parentElement.style.backgroundColor) {
            target.parentElement.style.backgroundColor = '';
            return;
         }

         if (selectedRow) {
            selectedRow.parentElement.style.backgroundColor = '';
         }

         target.parentElement.style.backgroundColor = '#413f5e';
         selectedRow = target;
      }
   });
}
