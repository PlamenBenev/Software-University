function solve(data,criteria){
    let parsing = JSON.parse(data);
    let result = [];

    if (criteria != 'all'){
        let [el,value] = criteria.split('-');
        let filtered = parsing.filter(x => x[el] == value);
        console.log(filtered);
        filtered.forEach(element => {
            result.push(`${element.id}. ${element.first_name} ${element.last_name} - ${element.email}`);

        })
    } else {
        parsing.forEach(element => {
            if (criteria == 'all'){
                result.push(`${element.id}. ${element.first_name} ${element.last_name} - ${element.email}`);
            } else {
            }     
        });

    }


    console.log(result.join('\n'));
    return result;
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
    }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
    },
    {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
    }]`,
    'gender-Female');