 function asd(input){
    const city = {};
    for (let item of input) {
        let [name,population] = item.split(' <-> ');
        population = Number(population);

        if (city.name != undefined){
            population += city[name];
        }

        city[name] = population;
    }
    for (const key in city) {
        console.log(key + ': ' + city[key]);
    }
}

asd(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']);
