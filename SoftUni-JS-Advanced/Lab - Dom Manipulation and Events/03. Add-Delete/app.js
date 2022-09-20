function addItem() {
    let items = document.getElementById('items');
    let addElement = document.getElementById('newItemText');
    let newLiElement = document.createElement('li');
    let deleteButton = document.createElement('a');
    deleteButton.href = '#';
    deleteButton.textContent = '[delete]';
    newLiElement.textContent = addElement.value;
    newLiElement.appendChild(deleteButton);
    items.appendChild(newLiElement);
    
    deleteButton.onclick = function() {
        deleteButton.parentElement.remove();
    }
}