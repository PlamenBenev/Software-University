async function getInfo() {
    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    let stopName = document.getElementById('stopName');
    let buses = document.getElementById('buses');
    
    try {
        stopName.textContent = 'Loading...'
        const res = await fetch(url);

        if (res.status !== 200){
            throw new Error('404 Not found');
        }
        const data = await res.json();
        
        let lis = buses.querySelectorAll('li');
        if (lis.length > 0){
            lis.forEach(x =>{
                x.remove();
            })
        }
        Object.entries(data.buses).forEach(b => {
            let li = document.createElement('li');
            li.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`;

            buses.appendChild(li);
        })

        stopName.textContent = data.name;
        
    } catch (error) {
        stopName.textContent = error;
    }
}