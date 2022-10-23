window.addEventListener('load', solve);

function solve() {
    let sendBtn = document.querySelector('button');

    sendBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let typeProd = document.getElementById('type-product');
        let description = document.getElementById('description');
        let clientName = document.getElementById('client-name');
        let clientPhone = document.getElementById('client-phone');

        let recievedOrders = document.getElementById('received-orders');
        let completedOrders = document.getElementById('completed-orders');

        if (description.value == '' || clientName.value == '' || clientPhone.value == '') {
            return;
        }

        let divContainer = document.createElement('div');
        divContainer.className = 'container';

        let h2 = document.createElement('h2');
        h2.textContent = `Product type for repair: ` + typeProd.value;
        let h3 = document.createElement('h3');
        h3.textContent = `Client information: ${clientName.value}, ${clientPhone.value}`;
        let h4 = document.createElement('h4');
        h4.textContent = `Description of the problem: ` + description.value;

        let startBtn = document.createElement('button');
        startBtn.className = 'start-btn';
        startBtn.textContent = 'Start repair';

        let finishBtn = document.createElement('button');
        finishBtn.className = 'finish-btn';
        finishBtn.disabled = true;
        finishBtn.textContent = 'Finish repair';

        divContainer.appendChild(h2);
        divContainer.appendChild(h3);
        divContainer.appendChild(h4);
        divContainer.appendChild(startBtn);
        divContainer.appendChild(finishBtn);
        recievedOrders.appendChild(divContainer);

        description.value = '';
        clientName.value = '';
        clientPhone.value = '';

        startBtn.addEventListener('click',()=>{
            startBtn.disabled = true;
            finishBtn.disabled = false;
        })
        finishBtn.addEventListener('click',()=>{
            divContainer.removeChild(finishBtn);
            divContainer.removeChild(startBtn);
            completedOrders.appendChild(divContainer);
        })

        let clearBtn = document.querySelector('.clear-btn');
        clearBtn.addEventListener('click',()=>{
            if (completedOrders.contains(divContainer)){
                completedOrders.removeChild(divContainer);
            }
        })
    })
}