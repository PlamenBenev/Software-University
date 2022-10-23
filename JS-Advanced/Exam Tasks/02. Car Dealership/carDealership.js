class CarDealership {
    constructor(name) {
        this.name = name;
        this.availavleCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage) {
        if (model == '' || typeof (model) != 'string' || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error('Invalid input!');
        }
        this.availavleCars.push({
            model: model,
            horsepower: horsepower,
            price: Number(price).toFixed(2),
            mileage: Number(mileage).toFixed(2)
        })
        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }
    sellCar(model, desiredMileage) {
        let theCar = this.availavleCars.find(x => x.model == model);
        if (theCar == undefined) {
            throw new Error(`${model} was not found!`);
        }
        
        if (desiredMileage < theCar.mileage){
            let diff = theCar.mileage - desiredMileage;
            if (diff <= 40000) {
                theCar.price -= theCar.price * 0.05;
            }
            if (diff > 40000) {
                theCar.price -= theCar.price * 0.10;
            }
        }

        this.soldCars.push({
            model: theCar.model,
            horsepower: theCar.horsepower,
            soldPrice: Number(theCar.price).toFixed(2)
        });
        this.totalIncome += Number(theCar.price);
        let carIndex = this.availavleCars.indexOf(theCar);
        this.availavleCars.splice(carIndex, 1);
        return `${model} was sold for ${Number(theCar.price).toFixed(2)}$`;
    }

    currentCar() {
        if (this.availavleCars.length == 0){
            return "There are no available cars";
        }

        let result = '-Available cars:\n';
        let arr = [];
        this.availavleCars.forEach(x => {
            arr.push(`---${x.model} - ${x.horsepower} HP - ${x.mileage} km - ${x.price}$`)
        })
        result += arr.join('\n');
        return result;
    }
    salesReport (criteria) {
        if (criteria == 'horsepower' || criteria == 'model'){
            if (criteria == 'horsepower' ){
                this.soldCars.sort((a,b) => b.horsepower - a.horsepower);
            } else {
                this.soldCars.sort((a,b)=> a.model.localeCompare(b.model));
            }

            let result = `-${this.name} has a total income of ${(this.totalIncome).toFixed(2)}$\n-${this.soldCars.length} cars sold:\n`;
            let arr = [];

            this.soldCars.forEach(x => {
                arr.push(`---${x.model} - ${x.horsepower} HP - ${x.soldPrice}$`);
            })
            result += arr.join('\n');
            return result;
        } else {
            throw new Error("Invalid criteria!");
        }
    }
}
let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
console.log(dealership.sellCar('Toyota Corolla', 230000));
console.log(dealership.sellCar('Mercedes C63', 110000));
