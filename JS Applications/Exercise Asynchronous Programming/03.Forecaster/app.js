function attachEvents() {
    let submitBtn = document.getElementById('submit');

    submitBtn.addEventListener('click', async () => {
        let forecast = document.getElementById('forecast');
        let url = `http://localhost:3030/jsonstore/forecaster/locations`
        let res = await fetch(url);
        let data = await res.json();
        let input = document.getElementById('location').value;

        // for current
        data.forEach(async element => {
            let current = document.getElementById('current');
            let upcoming = document.getElementById('upcoming');

            let div = document.createElement('div');
            div.className = 'forecasts';
            let symbol = document.createElement('span');
            symbol.className = 'condition symbol';
            symbol.textContent = `☀`;
            if (input === element.name) {
                let currUrl = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${element.code}`);
                let currData = await currUrl.json();

                let condition = document.createElement('span');
                condition.className = 'condition';

                let span1 = document.createElement('span');
                span1.className = 'forecast-data';
                let span2 = document.createElement('span');
                span2.className = 'forecast-data';
                let span3 = document.createElement('span');
                span3.className = 'forecast-data';
                span1.textContent = currData.name;
                span2.textContent = currData.forecast.low + `\xB0` + '/' + currData.forecast.high + `\xB0`;
                span3.textContent = currData.forecast.condition;

                condition.appendChild(span1);
                condition.appendChild(span2);
                condition.appendChild(span3);

                div.appendChild(symbol);
                div.appendChild(condition);
                current.appendChild(div);

                let upcomingUrl = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${element.code}`);
                let upcomingData = await upcomingUrl.json();
                console.log(upcomingData);
                let div2 = document.createElement('div');
                div.className = 'forecasts';

                upcomingData.forecast.forEach(x => {
                    let upcomingSpan = document.createElement('span');
                    upcomingSpan.className = 'upcoming';

                    let symbol2 = document.createElement('span');
                    symbol2.className = 'condition symbol';
                    symbol2.textContent = `⛅`;

                    let span22 = document.createElement('span');
                    span22.className = 'forecast-data';
                    let span33 = document.createElement('span');
                    span33.className = 'forecast-data';

                    span22.textContent = x.low + `\xB0` + '/' + x.high + `\xB0`;
                    span33.textContent = x.condition;
    
                    upcomingSpan.appendChild(symbol2);
                    upcomingSpan.appendChild(span22);
                    upcomingSpan.appendChild(span33);
                    div2.appendChild(upcomingSpan);
                });
                upcoming.appendChild(div2);
            }
        });
        forecast.style.display = 'block';
    })
}

attachEvents();