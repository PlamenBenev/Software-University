function solve() {
   let textArea = document.querySelector('textArea');
   let checkoutButton = document.getElementsByClassName('checkout')[0];
   let addButtons = document.getElementsByClassName('add-product');
   let prodArr = [];
   let totalPrice = 0;

   
   for (const button of addButtons) {
      let add = () => {
         console.log('added');
         let theProd = button.parentNode.parentNode;
         let theName = theProd.getElementsByClassName('product-title')[0].textContent;
         let thePrice = theProd.getElementsByClassName('product-line-price')[0].textContent;
         
         if (!prodArr.includes(theName)){
            prodArr.push(theName);
         }

         totalPrice += Number(thePrice);
         textArea.innerHTML += `Added ${theName} for ${thePrice} to the cart.\n`;
      }
      button.addEventListener('mousedown',add);
   }
   
   let checkout = () => {
      textArea.innerHTML += `You bought ${prodArr.join(', ')} for ${totalPrice.toFixed(2)}`
      checkoutButton.disabled = true;
      for (const buttons of addButtons) {
         buttons.disabled = true;
      }
   }
   checkoutButton.addEventListener('mousedown',checkout);
}