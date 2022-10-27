function solve(){
    let url = `http://localhost:3030/jsonstore/collections/books`;

    document.querySelector('form button').addEventListener('click',(e)=>{
        let title = document.getElementById('title');
        let author = document.getElementById('author');
    
        if (title.value == '' || author.value == ''){
            return;
        }
        e.preventDefault();
        createBook(url,title,author);
        loadBooks(url);

    })
    document.getElementById('loadBooks').addEventListener('click',(e)=>{
        e.preventDefault();

        loadBooks(url);
    })
}
solve();

function createBook(url,title,author){

    let request = {
        author: author.value,
        title: title.value
    }

    fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(request)
    })
    title.value = '';
    author.value = '';
}

function loadBooks(url){
    fetch(url).then(x => x.json())
    .then(x => {
        document.querySelector('tbody').innerHTML = '';
        Object.entries(x).forEach(r => {
            let tr = document.createElement('tr');
            let td1 = document.createElement('td');
            let td2 = document.createElement('td');
            let td3 = document.createElement('td');
            let editBtn = document.createElement('button');
            let deleteBtn = document.createElement('button');

            td1.textContent = r[1].author;
            td2.textContent = r[1].title;
            editBtn.textContent = 'Edit';
            deleteBtn.textContent = 'Delete';
            td3.appendChild(editBtn);
            td3.appendChild(deleteBtn);
        
            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);
        
            document.querySelector('tbody').appendChild(tr);

            let urlWithId = url + `/${r[0]}`;
            deleteBtn.addEventListener('click',()=>{
                deleteBook(urlWithId);
                tr.remove();
            })
            editBtn.addEventListener('click',()=>{    
                editBook(urlWithId,r[1].title,r[1].author);
            })
        })
    })
}
function deleteBook(url){
    fetch(url,{
        method: 'delete'
    })

}
function editBook(url,title,author){

    let record = {
        author: author,
        title: title,
    }

    fetch(url,{
        method: 'put',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(record)
    })
}