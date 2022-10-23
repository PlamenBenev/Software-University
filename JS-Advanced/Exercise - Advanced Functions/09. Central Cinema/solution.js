function solve() {
    let movies = document.getElementById('movies').querySelector('ul');
    let toArchive = document.getElementById('archive').querySelector('ul');
    let archButton = document.getElementById('archive').querySelector('button');
    let container = document.getElementById('container');
    let inputs = container.querySelectorAll('input');
    let onScreen = container.querySelector('button');

    onScreen.addEventListener('click', () => {
        if (inputs[0].value != '' && inputs[1].value != '' && inputs[2].value != '' && !isNaN(inputs[2].value)) {
            let li = document.createElement(`li`);

            let span = document.createElement(`span`);
            span.textContent = inputs[0].value;

            let strongOutside = document.createElement(`strong`);
            strongOutside.textContent = `Hall: ${inputs[1].value}`;

            let div = document.createElement('div');

            let strongInside = document.createElement('strong');
            strongInside.textContent = Number(inputs[2].value).toFixed(2);

            let input = document.createElement('input');
            input.placeholder = 'Tickets Sold';

            let archiveBtn = document.createElement('button');
            archiveBtn.textContent = 'Archive';

            archiveBtn.addEventListener('click', () => {
                if (!isNaN(input.value)) {
                    let strOut = li.querySelector('strong');
                    strOut.textContent = `Total amount: ${(input.value * strongInside.textContent).toFixed(2)}`;

                    li.removeChild(div);

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';
                    li.appendChild(deleteBtn);
                    deleteBtn.addEventListener('click', () => {
                        toArchive.removeChild(li);
                    });

                    toArchive.appendChild(li);
                }
            });

            div.appendChild(strongInside);
            div.appendChild(input);
            div.appendChild(archiveBtn);


            li.appendChild(span);
            li.appendChild(strongOutside);
            li.appendChild(div);

            movies.appendChild(li);

            archButton.addEventListener('click', () => {
                toArchive.removeChild(li);
            });
        }
        inputs.forEach(element => {
            element.value = '';
        });
    })

}