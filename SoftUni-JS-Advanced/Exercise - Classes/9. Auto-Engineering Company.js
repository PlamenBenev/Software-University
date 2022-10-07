function solve(arr){   
    class Car{
        constructor(brand,model,produced){
            this.brand = brand;
            this.model = [{model: model, produced: produced}];
            // this.produced = produced;
        }
    }
    let carsBrands = [];

    for (const iterator of arr) {
        let [_brand, _model, num] = iterator.split(' | ');
        let _produced = Number(num);
        let car = carsBrands.find(x => x.brand == _brand);

        if ( car != undefined){
            let findModel = car.model.find(x => x.model == _model);
            if (findModel != undefined){
               findModel.produced += _produced;
            } else {
                car.model.push({model: _model, produced: _produced});
            }
        } else {
            carsBrands.push(new Car(_brand,_model,_produced));
        }
    }

    for (const car of carsBrands) {
        console.log(car.brand);
        for (const item of car.model) {
            console.log(`###${item.model} => ${item.produced}`)
        }
    }
}
solve(['Audi | Q7 | 1000',
'Audi | Q7 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']);