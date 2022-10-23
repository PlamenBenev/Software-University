window.addEventListener("load", solve);

function solve() {
  let publishBtn = document.getElementById('form-btn');

  publishBtn.addEventListener('click', () => {
    let firstName = document.getElementById('first-name');
    let lastName = document.getElementById('last-name');
    let age = document.getElementById('age');
    let storyTitle = document.getElementById('story-title');
    let story = document.getElementById('story');
    let genre = document.getElementById('genre');

    let previewList = document.getElementById('preview-list');

    if (firstName.value == '' || lastName.value == '' || age.value == '' ||
      storyTitle.value == '' || story.value == '') {
      return;
    }

    let values = [
      firstName.value,
      lastName.value,
      age.value,
      storyTitle.value,
      story.value];

    let li = document.createElement('li');
    li.className = 'story-info';
    let article = document.createElement('article');
    let h4Name = document.createElement('h4');
    let p1Age = document.createElement('p');
    let p2Title = document.createElement('p');
    let p3Genre = document.createElement('p');
    let p4Story = document.createElement('p');
    let saveBtn = document.createElement('button');
    let editBtn = document.createElement('button');
    let deleteBtn = document.createElement('button');

    h4Name.textContent = 'Name: ' + firstName.value + ' ' + lastName.value;
    p1Age.textContent = 'Age: ' + age.value;
    p2Title.textContent = 'Title: ' + storyTitle.value;
    p3Genre.textContent = 'Genre: ' + genre.value;
    p4Story.textContent = story.value;

    saveBtn.className = 'save-btn';
    editBtn.className = 'edit-btn';
    deleteBtn.className = 'delete-btn';
    saveBtn.textContent = 'Save Story';
    editBtn.textContent = 'Edit Story';
    deleteBtn.textContent = 'Delete Story';

    article.appendChild(h4Name);
    article.appendChild(p1Age);
    article.appendChild(p2Title);
    article.appendChild(p3Genre);
    article.appendChild(p4Story);
    li.appendChild(article);
    li.appendChild(saveBtn);
    li.appendChild(editBtn);
    li.appendChild(deleteBtn);
    previewList.appendChild(li);

    publishBtn.disabled = true;

    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    story.value = '';

    editBtn.addEventListener('click', () => {
      firstName.value = values[0];
      lastName.value = values[1];
      age.value = values[2];
      storyTitle.value = values[3];
      story.value = values[4];

      li.remove();
      publishBtn.disabled = false;
    })

    saveBtn.addEventListener('click',()=>{
      let main = document.getElementById('main');
      let form = document.querySelector('.form-wrapper');
      let side = document.getElementById('side-wrapper');
      main.removeChild(form);
      main.removeChild(side);

      let h1 = document.createElement('h1');
      h1.textContent = "Your scary story is saved!";
      main.appendChild(h1);
    })

    deleteBtn.addEventListener('click',()=>{
      li.remove();
      publishBtn.disabled = false;
    })
  })
}
