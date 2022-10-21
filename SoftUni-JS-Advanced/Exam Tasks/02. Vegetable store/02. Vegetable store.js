class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let veges = [];
        vegetables.forEach(p => {
            let [type, quantity, price] = p.split(' ');
            let theVege = this.availableProducts.find(x => x.type == type);

            if (theVege != undefined) {
                theVege.quantity += Number(quantity);
                if (theVege.price < price) {
                    theVege.price = Number(price);
                }
            } else {
                this.availableProducts.push({
                    type: type,
                    quantity: Number(quantity),
                    price: Number(price)
                });
            }
            if (!veges.includes(type)){
                veges.push(type);
            }
        });
        return `Successfully added ${veges.join(', ')}`;
    }
    buyingVegetables (selectedProducts){
        let totalPrice = 0.00;
        selectedProducts.forEach(x => {
            let [type,quantity] = x.split(' ');
            let theVege = this.availableProducts.find(x => x.type == type);
            if (theVege == undefined){
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`                );
            }
            if (theVege.quantity < quantity){
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`                );
            }
            totalPrice += theVege.price * Number(quantity);
            theVege.quantity -= Number(quantity);
        });
        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }   
    rottingVegetable (type, quantity){
        let theVege = this.availableProducts.find(x => x.type == type);
        if (theVege == undefined){
            throw new Error(`${type} is not available in the store.`);
        }
        if (quantity > theVege.quantity){
            theVege.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }
        theVege.quantity -= quantity;
        return   `Some quantity of the ${type} has been removed.`;
    }
    revision (){
        let result = 'Available vegetables:\n';
        let arr = [];
        this.availableProducts.sort((a,b) => a.price - b.price);
        this.availableProducts.forEach(x => {
            arr.push(`${x.type}-${x.quantity}-$${x.price}`);
        })
        result += arr.join('\n');
        result += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return result;    
    }
}
