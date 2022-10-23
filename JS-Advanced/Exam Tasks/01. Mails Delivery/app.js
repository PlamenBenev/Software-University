function solve() {
    let addBtn = document.getElementById('add');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let recipientName = document.getElementById('recipientName');
        let title = document.getElementById('title');
        let message = document.getElementById('message');
        let data = [recipientName.value, title.value];


        if (recipientName.value == '' || title.value == '' || message.value == '') {
            return;
        }

        let listOfMails = document.getElementById('list');
        let deletedList = document.querySelector('.delete-list');

        let li = document.createElement('li');

        let h4Title = document.createElement('h4');
        h4Title.textContent = 'Title: ' + title.value;
        let h4Name = document.createElement('h4');
        h4Name.textContent = 'Recipient Name: ' + recipientName.value;
        let span = document.createElement('span');
        span.textContent = message.value;

        let div = document.createElement('div');
        div.id = 'list-action';
        let sendBtn = document.createElement('button');
        sendBtn.type = 'submit';
        sendBtn.textContent = 'Send';
        sendBtn.id = 'send';
        let deleteBtn = document.createElement('button');
        deleteBtn.type = 'submit';
        deleteBtn.textContent = 'Delete';
        deleteBtn.id = 'delete';

        div.appendChild(sendBtn);
        div.appendChild(deleteBtn);
        li.appendChild(h4Title);
        li.appendChild(h4Name);
        li.appendChild(span);
        li.appendChild(div);
        listOfMails.appendChild(li);

        sendBtn.addEventListener('click', () => {
            let sentList = document.querySelector('.sent-list');
            let sentLi = document.createElement('li');
            let sentSpan1 = document.createElement('span');
            sentSpan1.textContent = 'To: ' + data[0];
            let sentSpan2 = document.createElement('span');
            sentSpan2.textContent = 'Title: ' + data[1];
            let sentDiv = document.createElement('div');
            sentDiv.className = 'btn';
            let sentDeleteBtn = document.createElement('button');
            sentDeleteBtn.type = 'submit';
            sentDeleteBtn.textContent = 'Delete';
            sentDeleteBtn.className = 'delete';


            sentDiv.appendChild(sentDeleteBtn);
            sentLi.appendChild(sentSpan1);
            sentLi.appendChild(sentSpan2);
            sentLi.appendChild(sentDiv);
            sentList.appendChild(sentLi);
            li.remove();

            sentDeleteBtn.addEventListener('click', () => {
                sentLi.removeChild(sentDiv);

                deletedList.appendChild(sentLi);
            })
        })
        deleteBtn.addEventListener('click', () => {
            let deleteLi = document.createElement('li');
            let listSpan1 = document.createElement('span');
            listSpan1.textContent = 'To: ' + data[0];
            let listSpan2 = document.createElement('span');
            listSpan2.textContent = 'Title: ' + data[1];

            deleteLi.appendChild(listSpan1);
            deleteLi.appendChild(listSpan2);
            deletedList.appendChild(deleteLi);
            li.remove();
        })
    })

    let resetBtn = document.getElementById('reset');
    resetBtn.addEventListener('click', (e) => {
        e.preventDefault();
        let recipientName = document.getElementById('recipientName');
        let title = document.getElementById('title');
        let message = document.getElementById('message');
        recipientName.value = '';
        title.value = '';
        message.value = '';
    });
}
solve()