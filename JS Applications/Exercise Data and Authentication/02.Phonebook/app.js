function attachEvents() {
    const url = `http://localhost:3030/jsonstore/phonebook`;

    document.getElementById('btnLoad').addEventListener('click', (e) => {
        e.preventDefault();

        load();
    })
    document.getElementById('btnCreate').addEventListener('click', (e)=>{
        e.preventDefault();
        let person = document.getElementById('person');
        let phone = document.getElementById('phone');

        if (person.value == '' || phone.value == ''){
            return;
        }

        let record = {
            person: person.value,
            phone: phone.value
        }

        fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(record),
        });

        load();

        person.value = '';
        phone.value = '';
    })
}
function load(){
    document.getElementById('phonebook').innerHTML = '';
    const url = `http://localhost:3030/jsonstore/phonebook`;
    fetch(url)
    .then(x => x.json())
    .then(x => {

        Object.entries(x).forEach(r => {
            let li = document.createElement('li');
            let deleteBtn = document.createElement(`button`);
            
            deleteBtn.textContent = 'Delete';
            li.textContent = `${r[1].person}: ${r[1].phone}`
            document.getElementById('phonebook').appendChild(li).appendChild(deleteBtn);

            deleteBtn.addEventListener('click',()=>{
                fetch(`http://localhost:3030/jsonstore/phonebook/${r[1]._id}`,{
                    method: 'delete'
                });
                document.getElementById('phonebook').removeChild(li);
            })
        })
    })
}
attachEvents();