const url = `http://localhost:3030/jsonstore/collections/myboard/posts`;
const urlComments = `http://localhost:3030/jsonstore/collections/myboard/comments`;

const topicContainer = document.querySelector('.topic-container');

function solve() {
    const postButton = document.querySelector('.public');
    let inputs = document.querySelectorAll('input');
    let theContent = document.getElementById('postText')

    loadPosts();

    document.querySelector('.cancel').addEventListener('click',(e)=>{
        e.preventDefault();
        inputs[0].value = '';
        inputs[1].value = '';
        theContent.value = '';
    })
    
    postButton.addEventListener('click', (e) => {
        e.preventDefault();

        if (inputs[0].value == '' || inputs[1].value == '' || theContent.value == '') {
            alert('empty fields');
            return;
        }
        let record = {
            title: inputs[0].value,
            username: inputs[1].value,
            post: theContent.value
        }

        fetch(url, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(record)
        }).then(x => {
            sessionStorage.setItem('userId', x._id);
        })
        loadPosts();
    })

}
solve();

function loadPosts() {
    topicContainer.innerHTML = '';
    fetch(url).then(x => x.json())
        .then(x => {
            Object.entries(x).forEach(p => {
                let divNameWrapper = document.createElement('div');
                divNameWrapper.className = 'topic-name-wrapper';
                let divName = document.createElement('div');
                divName.className = 'topic-name';
                let aNormal = document.createElement('a');
                aNormal.className = 'normal';
                let h2Title = document.createElement('h2');
                h2Title.textContent = p[1].title;

                let divColumns = document.createElement('div');
                divColumns.className = 'columns';
                let div = document.createElement('div');
                let pDate = document.createElement('p');
                pDate.textContent = 'Date: ';
                let time = document.createElement('time');
                time.textContent = '2020-10-10T12:08:28.451Z';
                let divNickName = document.createElement('div');
                divNickName.className = 'nick-name';
                let pUsername = document.createElement('p');
                pUsername.textContent = 'Username: ';
                let spanUsername = document.createElement('span');
                spanUsername.textContent = p[1].username;


                aNormal.appendChild(h2Title);
                divName.appendChild(aNormal);
                pDate.appendChild(time);
                div.appendChild(pDate);
                pUsername.appendChild(spanUsername);
                divNickName.appendChild(pUsername);
                div.appendChild(divNickName);
                divColumns.appendChild(div);
                divName.appendChild(divColumns);
                divNameWrapper.appendChild(divName);
                topicContainer.appendChild(divNameWrapper);

                divName.addEventListener('click', (e) => {
                    e.preventDefault();
                    toThePost(p[1].username, p[1].post, p[1]._id);
                })
            })
        })
}

function toThePost(username, post, id) {
    document.getElementById('main').innerHTML = `<div class="comment">
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p><span>${username}</span> posted on <time>2020-10-10 12:08:28</time></p>

        <p class="post-content">${post}</p>
    </div>

    <div id="attachComment">
    </div>

    <div class="answer-comment">
    <p><span>currentUser</span> comment:</p>
    <div class="answer">
        <form>
            <textarea name="postText" id="comment" cols="30" rows="10"></textarea>
            <div>
                <label for="username">Username <span class="red">*</span></label>
                <input type="text" name="username" id="username">
            </div>
            <button id="commentBtn">Post</button>
        </form>
    </div>
</div>`
    loadComments(id);
    document.getElementById('commentBtn').addEventListener('click', (e) => {
        e.preventDefault();
        makeComment(id);
    })
}

function loadComments(postId) {
    fetch(urlComments).then(x => x.json())
        .then(x => {
            Object.entries(x).forEach(c => {
                if (c[1].id == postId) {
                    document.getElementById('attachComment').innerHTML += `<div id="user-comment">
                    <div class="topic-name-wrapper">
                    <div class="topic-name">
                    <p><strong>${c[1].username}</strong> commented on <time>3/15/2021, 12:39:02 AM</time></p>
                    <div class="post-content">
                    <p>${c[1].post}</p>
                    </div>
                    </div>
                    </div>
                    </div>
                    </div>`

                }
            })
        })
}

function makeComment(id) {
    const post = document.getElementById('comment');
    const username = document.getElementById('username');

    if (post.value == '' || username.value == ''){
        alert('Empty fields!');
        return;
    }

    const record = {
        post: post.value,
        username: username.value,
        id: id
    }

    fetch(urlComments, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(record)
    })

    loadComments(id);
}