window.addEventListener('load', solve);

function solve() {
    let addBtn = document.getElementById('add');
    
    addBtn.addEventListener('click',(event) => {
        let furnitureList = document.getElementById('furniture-list');
        let prodModel = document.getElementById('model');
        let prodPrice = document.getElementById('price');
        let prodYear = document.getElementById('year');
        let prodDescription = document.getElementById('description');

        let trClass = document.createElement('tr');
        trClass.className = 'info';
        
          let tdModel = document.createElement('td');
          tdModel.textContent = prodModel.value;
          let tdPrice = document.createElement('td');
          tdPrice.textContent = prodPrice.value;
          let tdAction = document.createElement('td');
          let lessInfoBtn = document.createElement('button');
          lessInfoBtn.className = 'moreBtn';
          lessInfoBtn.textContent = 'Less Info';
          let buyBtn = document.createElement('button');
          buyBtn.className = 'buyBtn';
          buyBtn.textContent = 'Buy it'

        let trClassHide = document.createElement('tr');
        trClassHide.className = 'hide';
        trClassHide.style = 'display: contents;';

          let tdYear = document.createElement('td');
          tdYear.textContent = prodYear.value;
          let tdDescription = document.createElement('td');
          tdDescription.textContent = prodDescription.value;
          tdDescription.colSpan = '3';
        
        trClassHide.appendChild(tdYear);
        trClassHide.appendChild(tdDescription);
        tdAction.appendChild(lessInfoBtn);
        tdAction.appendChild(buyBtn);
        trClass.appendChild(tdModel);
        trClass.appendChild(tdPrice);
        trClass.appendChild(tdAction);
        furnitureList.appendChild(trClass);
        furnitureList.appendChild(trClassHide);
        event.preventDefault();
    });

}
