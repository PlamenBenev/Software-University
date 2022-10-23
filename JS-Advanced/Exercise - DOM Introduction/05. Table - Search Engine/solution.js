function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let data = document.querySelectorAll('tbody tr');
      let searchField = document.getElementById('searchField');

      for (const item of data) {
         if (item.textContent.includes(searchField.value) && searchField.value != '') {
              item.className = 'select';
         } else {
            item.className = '';
         }
      }
   }
}