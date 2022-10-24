function solve() {
    let id = 'depot';
    const req = `http://localhost:3030/jsonstore/bus/schedule/${id}`;
    let info = document.getElementById('info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');


    async function depart() {
        try {
            let res = await fetch(req);
    
            if (res.status !== 200) {
                throw new Error('Error');
            }
            let data = await res.json();
    
            info.textContent = `Next stop ${data.name}`;
            departBtn.disabled = true;
            arriveBtn.disabled = false;
    
            id = data.next;
        } catch (error) {
            info.textContent = `Error`;
        }
    }

    async function arrive() {
        try {
            let res = await fetch(req);
    
            if (res.status !== 200) {
                throw new Error('Error');
            }
            let data = await res.json();
    
            info.textContent = `Arriving at ${data.name}`;
            departBtn.disabled = false;
            arriveBtn.disabled = true;
    
            id = data.next;
        } catch (error) {
            info.textContent = `Error`;
        }
    }

    return {
        depart,
        arrive
    };
}

let result = solve();