function solve() {
    document.getElementById('submit').addEventListener('click', (e) => {
        e.preventDefault();

        let url = `http://localhost:3030/jsonstore/collections/students`;
        createStudent(url);

        let tbody = document.querySelector('tbody');
        tbody.innerHTML = '';

        fetch(url)
            .then(x => x.json())
            .then(x => {
                Object.entries(x).forEach(r => {
                    let tr = document.createElement('tr');

                    let tr1 = document.createElement('th');
                    tr1.textContent = r[1].firstName;
                    let tr2 = document.createElement('th');
                    tr2.textContent = r[1].lastName;
                    let tr3 = document.createElement('th');
                    tr3.textContent = r[1].facultyNumber;
                    let tr4 = document.createElement('th');
                    tr4.textContent = r[1].grade;

                    tr.appendChild(tr1);
                    tr.appendChild(tr2);
                    tr.appendChild(tr3);
                    tr.appendChild(tr4);
                    tbody.appendChild(tr);
                })
            })
    })
}


function createStudent(url) {
    // let url = `http://localhost:3030/jsonstore/collections/students`;
    let inputs = document.querySelectorAll('input');

    if (inputs[0].value == '' || inputs[1].value == '' ||
        inputs[2].value == '' || inputs[3].value == '' ){
            return;
        }

        let record = {
            firstName: inputs[0].value,
            lastName: inputs[1].value,
            facultyNumber: inputs[2].value,
            grade: Number(inputs[3].value).toFixed(2),
        }

    fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(record)
    })
    inputs[0].value = '';
    inputs[1].value = '';
    inputs[2].value = '';
    inputs[3].value = '';
}

solve();