window.addEventListener('load', solution);

function solution() {
  let submBtn = document.getElementById('submitBTN')

  submBtn.addEventListener('click', (e) => {
    let fName = document.getElementById('fname');
    let email = document.getElementById('email');
    let phone = document.getElementById('phone');
    let address = document.getElementById('address');
    let code = document.getElementById('code');

    if (fName.value == '' || email.value == '' || phone.value < 0) {
      return;
    }

    let data = [fName.value, email.value, phone.value, address.value, code.value]

    let infoPreview = document.getElementById('infoPreview');

    let liName = document.createElement('li');
    let liEmail = document.createElement('li');
    let liPhone = document.createElement('li');
    let liAddress = document.createElement('li');
    let liCode = document.createElement('li');

    liName.textContent = 'Full Name: ' + fName.value;
    liEmail.textContent = 'Email: ' + email.value;
    liPhone.textContent = 'Phone Number: ' + phone.value;
    liAddress.textContent = 'Address: ' + address.value;
    liCode.textContent = 'Postal Code: ' + code.value;

    infoPreview.appendChild(liName);
    infoPreview.appendChild(liEmail);
    if (phone.value != '') {
      infoPreview.appendChild(liPhone);
    }
    if (address.value != '') {
      infoPreview.appendChild(liAddress);
    }
    if (code.value != '') {
      infoPreview.appendChild(liCode);
    }

    fName.value = '';
    email.value = '';
    phone.value = '';
    address.value = '';
    code.value = '';

    submBtn.disabled = true;
    /////////////////////////////////////////

    let editBtn = document.getElementById('editBTN');
    let continueBtn = document.getElementById('continueBTN');

    editBtn.disabled = false;
    continueBtn.disabled = false;

    editBtn.addEventListener('click', () => {
      fName.value = data[0];
      email.value = data[1];
      phone.value = data[2];
      address.value = data[3];
      code.value = data[4];
      removeAllChildNodes(infoPreview);

      submBtn.disabled = false;
      editBtn.disabled = true;
      continueBtn.disabled = true;
    });

    continueBtn.addEventListener('click', () => {
      let block = document.getElementById('block');

      removeAllChildNodes(block);
      let h3 = document.createElement('h3');
      h3.innerHTML = 'Thank you for your reservation!';
      block.appendChild(h3);
    });
  });

  function removeAllChildNodes(parent) {
    while (parent.firstChild) {
      parent.removeChild(parent.firstChild);
    }
  }
}
