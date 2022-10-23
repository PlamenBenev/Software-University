class Garden {
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant (plantName, spaceRequired){
        if (this.spaceAvailable < spaceRequired){
            throw new Error("Not enough space in the garden.");
        }
        this.plants.push({
            plantName: plantName,
            spaceRequired: spaceRequired,
            ripe: false,
            quantity: 0
        })
        this.spaceAvailable -= spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity){
        let thePlant = this.plants.find(x=> x.plantName == plantName);
        if (thePlant == undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (thePlant.ripe == true){
            throw new Error(`The ${plantName} is already ripe.`);
        }
        if (quantity <= 0){
            throw new Error(`The quantity cannot be zero or negative.`);
        }
        thePlant.ripe = true;
        thePlant.quantity += quantity
        if (quantity == 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        } else {
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName) {
        let thePlant = this.plants.find(x=> x.plantName == plantName);

        if (thePlant == undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (thePlant.ripe == false){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }
        this.storage.push({
            plantName: plantName,
            quantity: thePlant.quantity
        })
        this.spaceAvailable += thePlant.spaceRequired;
        let thePlantIndex =  this.plants.indexOf(thePlant);
        this.plants.splice(thePlantIndex,1);
        return `The ${plantName} has been successfully harvested.`;
    }
    generateReport(){
        let result = `The garden has ${this.spaceAvailable } free space left.\n` +
        'Plants in the garden: ';
        
        this.plants.sort((a, b)  => a.plantName.localeCompare(b.plantName));
        let names = [];
        this.plants.forEach(x => {
            names.push(x.plantName);
        })
        result += names.join(', ') + '\n';
        
        if (this.storage.length == 0){
            result += "Plants in storage: The storage is empty.";
        } else {
            result += `Plants in storage: `;
            let arr = [];
            this.storage.forEach(x => {
                arr.push(`${x.plantName} (${x.quantity})`);
            });
            result += arr.join(', ');
        }
        return result;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());
