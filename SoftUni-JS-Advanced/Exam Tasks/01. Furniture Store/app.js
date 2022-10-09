window.addEventListener('load', solve);

function solve() {
    let addBtn = document.getElementById('add');
    
    addBtn.addEventListener('click',(event) => {
     
        let furnitureList = document.getElementById('furniture-list');
        let prodModel = document.getElementById('model');
        let prodPrice = document.getElementById('price');
        let prodYear = document.getElementById('year');
        let prodDescription = document.getElementById('description');
        
        if (prodModel.value == '' || prodDescription.value == '' || prodPrice.value == '' || prodYear.value == ''
        || prodPrice.value < 0 || prodYear.value < 0){
          return;
        }
          
        let trClass = document.createElement('tr');
        trClass.className = 'info';
        
          let tdModel = document.createElement('td');
          tdModel.textContent = prodModel.value;
          let tdPrice = document.createElement('td');
          tdPrice.textContent = Number(prodPrice.value).toFixed(2);
          let tdAction = document.createElement('td');
          let infoBtn = document.createElement('button');
          infoBtn.className = 'moreBtn';
          infoBtn.textContent = 'More Info';
          let buyBtn = document.createElement('button');
          buyBtn.className = 'buyBtn';
          buyBtn.textContent = 'Buy it'

        let trClassHide = document.createElement('tr');
        trClassHide.className = 'hide';
        trClassHide.style.display = 'none';

          let tdYear = document.createElement('td');
          tdYear.textContent = 'Year: ' + prodYear.value;
          let tdDescription = document.createElement('td');
          tdDescription.textContent = 'Description: ' + prodDescription.value;
          tdDescription.colSpan = '3';

          infoBtn.addEventListener('click', () => {
            if (infoBtn.textContent == 'More Info'){
              trClassHide.style.display = 'contents';
              infoBtn.textContent = 'Less Info'
            } else {
              infoBtn.textContent = 'More Info'
              trClassHide.style.display = 'none';
            }
          });
          buyBtn.addEventListener('click',() => {
            let totalPrice = document.getElementsByClassName('total-price');
            let curPrice = Number(totalPrice[0].textContent);
            totalPrice[0].textContent = (curPrice + Number(prodPrice.value)).toFixed(2);
            furnitureList.removeChild(trClass);
          });

        trClassHide.appendChild(tdYear);
        trClassHide.appendChild(tdDescription);
        tdAction.appendChild(infoBtn);
        tdAction.appendChild(buyBtn);
        trClass.appendChild(tdModel);
        trClass.appendChild(tdPrice);
        trClass.appendChild(tdAction);
        furnitureList.appendChild(trClass);
        furnitureList.appendChild(trClassHide);
        event.preventDefault();
    });
}
