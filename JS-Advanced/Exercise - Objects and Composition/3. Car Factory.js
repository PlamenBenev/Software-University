function result(param) {
    const car = {};
    car.model = param.model;
    if (param.power < 120){
        car.engine = {
            power: 90,
            volume: 1800
        }
    } else if (param.power < 200 && param.power >= 120) {
        car.engine = {
            power: 120,
            volume: 2400
        }
    } else if (param.power >= 200){
        car.engine = {
            power: 200,
            volume: 3500
        }
    }

    car.carriage = {
        type: param.carriage,
        color: param.color
    }
    let size;
    if (param.wheelsize % 2 == 0)
    {
        size = param.wheelsize - 1;
    } else {
        size = param.wheelsize;
    }
    car.wheelsize = [size,size,size,size];
    return car;
}

let input = {
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
};

let expected = {
    model: 'VW Golf II',
    engine: {
        power: 90,
        volume: 1800
    },
    carriage: {
        type: 'hatchback',
        color: 'blue'
    },
    wheels: [13, 13, 13, 13]
};

let output = result(input);
console.log(output);