function solve() {
    let addBtn = document.getElementById('add-worker');

    addBtn.addEventListener('click',(e)=>{
        e.preventDefault();
        let inputs = document.querySelectorAll('form input');
        let tbody = document.getElementById('tbody');
        let tr = document.createElement('tr');
        let btnsTd = document.createElement('td');
        let fired = document.createElement('button');
        fired.className = 'fired';
        fired.textContent = 'Fired';
        let edit = document.createElement('button');
        edit.className = 'edit';
        edit.textContent = 'Edit';

        let returner = false;
        Array.from(inputs).forEach(x => {
            if (x.value == ''){
                returner = true;
            }
        })
        if (returner){return};
        
        let text = [inputs[0].value, inputs[1].value, inputs[2].value,
        inputs[3].value,inputs[4].value,inputs[5].value,]

        for (let i = 0; i < text.length; i++) {
            let td = document.createElement('td');
            td.textContent = text[i];
            tr.appendChild(td);
        }

        btnsTd.appendChild(fired);
        btnsTd.appendChild(edit);
        tr.appendChild(btnsTd);
        tbody.appendChild(tr);

        Array.from(inputs).forEach(x => {
            x.value = '';
        })

        let budget = document.getElementById('sum');
        budget.textContent = (Number(budget.textContent) + Number(text[5])).toFixed(2);
        ////////
        edit.addEventListener('click',() => {
            for (let i = 0; i < inputs.length; i++) {
                inputs[i].value = text[i];
            }
            budget.textContent = (Number(budget.textContent) - Number(text[5])).toFixed(2);
            tr.remove();
        });
        fired.addEventListener('click',()=>{
            budget.textContent = (Number(budget.textContent) - Number(text[5])).toFixed(2);
            tr.remove();
        });
    });
}
solve()