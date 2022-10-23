function result(param) {
    let input = {};

    for (const items of param) {
    let [town, prod, price] = items.split(" | ");
    price = Number(price);

      if (!input[prod]){
            input[prod] = {town,price: price};
        } else if (input[prod].price > price){
            input[prod].price = price;
            input[prod].town = town;
     }
   }

   let result = [];

   for (const item in input) {
        result.push(item + " -> " + input[item].price + " (" + input[item].town + ") ");
   }
   return result.join("\n");
}

console.log(result(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']));