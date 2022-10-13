 window.addEventListener("load", solve);

function solve() {
  let pubBtn = document.getElementById('publish');

  pubBtn.addEventListener('click', (e) => {
    e.preventDefault();
    let tBody = document.getElementById('table-body');
    let trClass = document.createElement('tr');
    trClass.className = 'row';

    let make = document.getElementById('make');
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let fuel = document.getElementById('fuel');
    let originalCost = document.getElementById('original-cost');
    let sellingPrice = document.getElementById('selling-price');

    if (make.value == '' || model.value == '' || year.value == '' || year.value < 1970
    || originalCost.value == '' || year.value > 2022 ||  originalCost.value < 0 || sellingPrice <0 ||
      sellingPrice.value == '' || fuel.value == '' || originalCost.value > sellingPrice.value) {
      return;
    }

    let elementsValues = [];
    for (let i = 0; i < 6; i++) {
      let x = document.createElement('td');
      elementsValues.push(x);
    }

    elementsValues[0].textContent = make.value;
    elementsValues[1].textContent = model.value
    elementsValues[2].textContent = year.value
    elementsValues[3].textContent = fuel.value
    elementsValues[4].textContent = originalCost.value
    elementsValues[5].textContent = sellingPrice.value

    let editBtn = document.createElement('button');
    editBtn.className = 'action-btn edit';
    editBtn.textContent = 'Edit';
    let sellBtn = document.createElement('button');
    sellBtn.className = 'action-btn sell';
    sellBtn.textContent = 'Sell'

    trClass.appendChild(elementsValues[0]);
    trClass.appendChild(elementsValues[1]);
    trClass.appendChild(elementsValues[2]);
    trClass.appendChild(elementsValues[3]);
    trClass.appendChild(elementsValues[4]);
    trClass.appendChild(elementsValues[5]);
    trClass.appendChild(editBtn);
    trClass.appendChild(sellBtn);
    tBody.appendChild(trClass);

    make.value = '';
    model.value = '';
    year.value = '';
    fuel.value = '';
    originalCost.value = '';
    sellingPrice.value = '';

    editBtn.addEventListener('click',() => {
      make.value = elementsValues[0].textContent;
      model.value = elementsValues[1].textContent;
      year.value = elementsValues[2].textContent;
      fuel.value = elementsValues[3].textContent;
      originalCost.value = elementsValues[4].textContent;
      sellingPrice.value = elementsValues[5].textContent;

      tBody.removeChild(editBtn.parentNode);
    });
    sellBtn.addEventListener('click',() => {
      tBody.removeChild(sellBtn.parentNode);
      let carsList = document.getElementById('cars-list');
      let li = document.createElement('li');
      li.className = 'each-list'
      let span1 = document.createElement('span');
      let span2 = document.createElement('span');
      let span3 = document.createElement('span');
      let profit = document.getElementById('profit');

      span1.textContent = elementsValues[0].textContent + ' ' + elementsValues[1].textContent;
      span2.textContent = elementsValues[3].textContent;
      span3.textContent = Number(elementsValues[5].textContent) - Number(elementsValues[4].textContent);

      li.appendChild(span1);
      li.appendChild(span2);
      li.appendChild(span3);
      carsList.appendChild(li);

      let theProfit = Number(profit.textContent) + Number(span3.textContent);
      profit.textContent = theProfit.toFixed(2);
    });
  })
}
