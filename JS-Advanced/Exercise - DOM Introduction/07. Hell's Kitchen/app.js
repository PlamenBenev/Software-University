function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let textInput = document.querySelector('textarea').value;
      let parsing = JSON.parse(String(textInput));
      let getBestRestaurant = document.getElementById('bestRestaurant').querySelector('p');
      let getWorkers = document.getElementById('workers').querySelector('p');

      let restaurants = {};
      
      for (const item of parsing) {        
         let [theRestaurant,theWorkersWithSalaries] = item.split(' - ');
         let everyWorker = theWorkersWithSalaries.split(', ');

         let theSalaries = [];
         let stringToReturn = [];
         let topSalary = 0;

         
         for (const worker of everyWorker) {
            let [workerName,hisSalary] = worker.split(' ');
            
            if (topSalary < Number(hisSalary)){
               topSalary = Number(hisSalary);
            }

            if (Number(hisSalary) < theSalaries[0]){
               theSalaries.push(Number(hisSalary));
               stringToReturn.push(`Name: ${workerName} With Salary: ${hisSalary}`);
            } else {
               theSalaries.unshift(Number(hisSalary));
               stringToReturn.unshift(`Name: ${workerName} With Salary: ${hisSalary}`);
            }
         }
         let avrg = theSalaries.reduce((a,b) => a+b) / theSalaries.length;

         restaurants[theRestaurant] = {
            name: 'Name: ' + theRestaurant,
            averageSalary: ' Average Salary: ' + avrg.toFixed(2),
            workers: stringToReturn.join(' '),
            avrg: avrg.toFixed(2),
            topSalary: ' Best Salary: ' + topSalary.toFixed(2)
         }
      }
      let theBest;

      for (const key in restaurants) {
         if (theBest == undefined || restaurants[key].avrg > theBest.avrg){
            theBest = restaurants[key];
         }
      }
      
      getBestRestaurant.innerHTML = theBest.name + theBest.averageSalary + theBest.topSalary;
      getWorkers.innerHTML = theBest.workers;
   }
   // ["PizzaHut - Peter 500, George 300, Mark 800","TheLake - Bob 1300, Joe 780, Jane 660"]
   // ["Mikes - Steve 1000, Ivan 200, Paul 800","Fleet - Janet 650, Maria 850"]
}