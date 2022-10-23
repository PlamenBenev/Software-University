window.addEventListener("load", solve);

function solve() {
  let publishBtn = document.getElementById('publish-btn');

  publishBtn.addEventListener('click',() => {
    let postTitle = document.getElementById('post-title');
    let postCategory = document.getElementById('post-category');
    let postContent = document.getElementById('post-content');

    if (postTitle.value == '' || postCategory.value == '' || postContent.value == ''){
      return;
    }

    let postReview = document.getElementById('review-list');

    let li = document.createElement('li');
    li.className = 'rpost';
    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    let pCategory = document.createElement('p');
    let pContent = document.createElement('p');

    let editBtn = document.createElement('button');
    editBtn.className = 'action-btn edit';
    editBtn.textContent = 'Edit';
    let approveBtn = document.createElement('button');
    approveBtn.className = 'action-btn approve';
    approveBtn.textContent = 'Approve';
    let clearBtn = document.getElementById('clear-btn');

    let values = [postTitle.value,postCategory.value,postContent.value];

    h4.textContent = postTitle.value;
    pCategory.textContent = 'Category: ' + postCategory.value;
    pContent.textContent = 'Content: ' + postContent.value;

    article.appendChild(h4);
    article.appendChild(pCategory);
    article.appendChild(pContent);
    li.appendChild(article);
    li.appendChild(editBtn);
    li.appendChild(approveBtn);
    postReview.appendChild(li);

    postTitle.value = '';
    postCategory.value = '';
    postContent.value = '';

    editBtn.addEventListener('click',() =>{
      postTitle.value = values[0];
      postCategory.value = values[1];
      postContent.value = values[2];

     // editBtn.parentNode.parentNode.removeChild(editBtn.parentNode);
     editBtn.parentElement.remove();
    });

    let publishedList = document.getElementById('published-list');

    approveBtn.addEventListener('click',() => {
      li.removeChild(editBtn);
      li.removeChild(approveBtn);

      publishedList.appendChild(li);
    });
    clearBtn.addEventListener('click',()=>{
      function clear(parent){
        while (parent.firstChild){
          parent.removeChild(parent.firstChild);
        }
      }
      clear(publishedList);
    });
  });
}
