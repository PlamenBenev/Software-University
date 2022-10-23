function solve(arr,criteria){
    class Ticket{
        constructor(destination,price,status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    arr.forEach(element => {
        let [destination,price,status] = element.split('|');
        tickets.push({
            destination: destination,
            price: price,
            status: status
        });
    });
    function compare( a, b ) {
        if ( a[criteria] < b[criteria] ){
          return -1;
        }
        if ( a[criteria] > b[criteria]){
          return 1;
        }
        return 0;
      }
    
      tickets.sort(compare);

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
'Boston|126.20|departed',
'New York City|95.99|available',
'New York City|95.99|sold'],
'destination'))