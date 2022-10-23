function addItem() {
    let items = document.getElementById('items');
    let newItem = document.createElement('li');
    let input = document.getElementById('newItemText');
    newItem.textContent = input.value;
    items.appendChild(newItem);
}