function attachEvents() {
    document.getElementById('submit').addEventListener('click', () => {
        const author = document.querySelector('[name="author"]');
        const content = document.querySelector('[name="content"]');

        let data = {
            author: author.value,
            content: content.value
        }
        sendMessage(data);
        author.value = '';
        content.value = '';
    })
    document.getElementById('refresh').addEventListener('click', () => {
        const url = `http://localhost:3030/jsonstore/messenger`;
        fetch(url)
            .then(h => h.json())
            .then(s => {
                const messages = Object.values(s).map(x => `${x.author}: ${x.content}`).join('\n');
                document.getElementById('messages').value = messages;
            })
    })
}

async function sendMessage(message) {
    const url = `http://localhost:3030/jsonstore/messenger`;
    fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(message),
        }
    )
    // const response = await fetch(url, {
    //     method: 'post',
    //     headers: { 'Content-Type': 'application/json' },
    //     body: JSON.stringify(message),
    // });
}
attachEvents();