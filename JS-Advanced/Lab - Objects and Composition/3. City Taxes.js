 function asd(name,population,treasary){
    return {
    name: name,
    population: population,
    treasary: treasary,
    taxRate: 10,
    collectTaxes(){
         treasary += population * taxRate;
    },
    applyGrowth(percent){
        population += Math.floor(population * percent / 100);
    },
    applyRecession(percent){
        treasary -= Math.floor(treasary * percent / 100);
    },
};
}

const city =
asd('Tortuga',
7000,
15000);
console.log(city);
