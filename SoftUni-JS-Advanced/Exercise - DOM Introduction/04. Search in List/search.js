function search() {
   let theTowns = document.querySelectorAll('li');
   let theSearch = document.getElementById('searchText');
   let theResult = document.getElementById('result');
   let counter = 0;
   for (const item of theTowns) {
      if (item.textContent.includes(theSearch.value)){
         counter++;
         item.style.textDecoration = 'underline';
         item.style.fontWeight = 'bold';
      }
   }
   theResult.textContent = counter + ' matches found';
}
