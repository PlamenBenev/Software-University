function solve() {
  let tbody = document.querySelectorAll('tbody')[0];
  let output = document.querySelectorAll('textarea')[1];
  let buttons = document.querySelectorAll('button');
  let finput = document.querySelectorAll('textarea')[0];

  document.querySelectorAll('button')[0].addEventListener('click', () => {
    const input = JSON.parse(finput.value);

    input.forEach((el) => {
        const productRowString =
            '<tr>' +
            `<td><img src="${el.img}"></td>` +
            `<td><p>${el.name}</p></td>` +
            `<td><p>${el.price}</p></td>` +
            `<td><p>${el.decFactor}</p></td>` +
            `<td><input type="checkbox" /></td>` +
            '</tr>';
        tbody.insertAdjacentHTML('beforeEnd', productRowString);
    });

    finput.value = '';
});
  
  // buttons[0].addEventListener('mousedown',() => {
    
  //   let input = document.querySelectorAll('textarea')[0];
  //   let tr = document.createElement('tr');
  //   let parsing = JSON.parse(input.value);

  //   for (let p = 0; p < parsing.length; p++) {
  //     let img = document.createElement('img');
  //     img.src = parsing[0].img;
  //     let checkBox = document.createElement('input');
  //     checkBox.type = 'checkbox';
    
  //     let allTd = [];
  //     let paragraphs = [];
    
  //     for (let i = 0; i < 5; i++) {
  //       allTd.push(document.createElement('td'));
  //     }
    
  //     for (let i = 0; i < 3; i++) {
  //       paragraphs.push(document.createElement('p'));     
  //     }
    
  //     //let p = document.createElement('p');
  //     paragraphs[0].textContent = parsing[0].name;
  //     paragraphs[1].textContent = parsing[0].price;
  //     paragraphs[2].textContent = parsing[0].decFactor;
      
  //     allTd[0].appendChild(img);
  //     allTd[1].appendChild(paragraphs[0]);
  //     allTd[2].appendChild(paragraphs[1]);
  //     allTd[3].appendChild(paragraphs[2]);
  //     allTd[4].appendChild(checkBox);
      
  //     tr.appendChild(allTd[0]);
  //     tr.appendChild(allTd[1]);
  //     tr.appendChild(allTd[2]);
  //     tr.appendChild(allTd[3]);
  //     tr.appendChild(allTd[4]);
  //     tbody.appendChild(tr);

  //     input.value = '';
  //   }
  // })

 // buttons[0].onclick = function(){
 // }
  
  buttons[1].addEventListener('mousedown',() => {
    let checkboxes = document.querySelectorAll('input');
    let bought = [];
    let totalPrice = 0;
    let decFactors = 0;

    for (let i = 0; i < checkboxes.length; i++) {
      if (checkboxes[i].checked){
        let parent = checkboxes[i].parentElement.parentElement.querySelectorAll('td');
        bought.push(parent[1].textContent.trim());
        totalPrice += Number(parent[2].textContent);
        decFactors += Number(parent[3].textContent);
      }
    }
    
    output.value = `Bought furniture: ${bought.join(', ')}\n`;
    output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
    output.value += `Average decoration factor: ${(decFactors / checkboxes.length).toFixed(2)}`;
  });
}