function generateReport() {
    let toReturn = [];
    let data = document.querySelectorAll('tbody tr');
    let boxes = document.querySelectorAll('thead tr th input');
    let output = document.getElementById('output');

    for (let i = 0; i < boxes.length; i++) {
        for (let k = 0; k < data.length; k++) {
            let object = {};
            let test = data[k].querySelectorAll('td');
            if (boxes[0].checked) { object['employee'] = test[0].textContent; }
            if (boxes[1].checked) { object['department'] = test[1].textContent; }
            if (boxes[2].checked) { object['status'] = test[2].textContent; }
            if (boxes[3].checked) { object['dateHired'] = test[3].textContent; }
            if (boxes[4].checked) { object['benefits'] = test[4].textContent; }
            if (boxes[5].checked) { object['conpensation'] = test[5].textContent; }
            if (boxes[6].checked) { object['rating'] = test[6].textContent; }

            toReturn.push(object);
        }
    }

    output.textContent = JSON.stringify(toReturn);

}