function solve(arr) {
  class Juice {
    constructor(prod, quantity) {
      this.prod = prod;
      this.quantity = Number(quantity);
      this.bottles = 0;
    }
    addQuantity(n) {
      return this.quantity += n;
    }
    calcBottles() {
      let bottle = Math.floor(this.quantity / 1000);
      if (bottle > 0) {
        for (let i = 0; i < bottle; i++) {
          this.quantity -= 1000;
        }
      }
      return this.bottles += bottle;
    }
  }
  let juices = [];

  arr.forEach(element => {
    let [prod, quantity] = element.split(' => ');
    let juice = new Juice(prod, Number(quantity));

    if (juices.find(x => x.prod == juice.prod)) {
      juices.find(x => x.prod == juice.prod).addQuantity(Number(quantity));
      juices.find(x => x.prod == juice.prod).calcBottles();
    } else {
      juice.calcBottles();
      juices.push(juice);
    }
  });


  juices.forEach(x => {
    console.log(x.prod + ` => ` + x.bottles);
  })
}

solve(['Kiwi => 234',
  'Pear => 2345',
  'Watermelon => 3456',
  'Kiwi => 4567',
  'Pear => 5678',
  'Watermelon => 6789']);
// function solve(arr) {
//   let obj = {};

//   arr.forEach(element => {
//     let [product, quantity] = element.split(' => ');
//     if (obj[product] == undefined) {
//       obj[product] = {
//         quantity: Number(quantity),
//         bottle: 0
//       };
//     } else {
//       obj[product].quantity += Number(quantity);
//     }
//   });

//   for (const prod in obj) {
//       obj[prod].bottle = Math.floor(obj[prod].quantity / 1000);
//   }
//   for (const prod in obj) {
//     if (obj[prod].bottle != 0) {
//       console.log(`${prod} => ${obj[prod].bottle}`);
//     }
//   }
// }