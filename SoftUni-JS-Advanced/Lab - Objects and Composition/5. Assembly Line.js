function createAssemblyLine() {
         function hasClima(theCar){
              const car = theCar;
                    car.temp = 21;
                    car.tempSettings = 21;
                    car.adjustTemp =  function adjustTempreture(){
                      if (this.temp < this.tempSettings){
                       this.temp++;
                       } else if (this.temp > this.tempSettings){
                        this.temp--;
                       }
                    }       
        }
        function hasAudio(theCar){
            const newCar = theCar;
            newCar.currentTrack = {
                name: null,
                artist: null
            }
            newCar.nowPlaying = function playing(){
                if (newCar.currentTrack != null){
                console.log("Now playing '" + newCar.currentTrack.name 
                + "' by " + newCar.currentTrack.artist);
                }
            }
        }
        function hasParktronic(theCar){
            const car = theCar;
            car.checkDistance = function distance(number){
                let distance = Number(number);
                if (distance < 0.1){
                    console.log("Beep! Beep! Beep!");
                } else if (distance >= 0.1 && distance < 0.25){
                    console.log("Beep! Beep!");
                } else if (distance >= 0.25 && distance < 0.5){
                    console.log("Beep!");
                }
            }
        }
        return {hasClima,hasAudio,hasParktronic};   
}

const assemblyLine = createAssemblyLine();
const myCar = {
make: 'Toyota',
model: 'Avensis'
};
assemblyLine.hasClima(myCar);

console.log(myCar.temp);

myCar.tempSettings = 18;

myCar.adjustTemp();

console.log(myCar.temp);

assemblyLine.hasAudio(myCar);

myCar.currentTrack = {

name: 'Never Gonna Give You Up',

artist: 'Rick Astley'

};

myCar.nowPlaying();
assemblyLine.hasParktronic(myCar);

myCar.checkDistance(0.4);

myCar.checkDistance(0.2);

console.log(myCar);
