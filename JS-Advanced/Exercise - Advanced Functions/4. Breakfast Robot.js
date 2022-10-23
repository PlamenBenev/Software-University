function solution() {
    let availible = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    function manager(input) {
        let [task, prod, quantity] = input.split(' ');
        let quant = Number(quantity);
        let message;
        if (task == 'restock') {
            if (availible[prod] > 0) {
                availible[prod] += Number(quantity);
            } else {
                availible[prod] = Number(quantity);
            }
            message = 'success';
        } else if (task == 'prepare') {
            for (const key in availible) {
                if (quant * recipes[prod][key] <= availible[key]){
                    availible[key] -= quant * recipes[prod][key];
                    message = 'success';
                } else if (quant * recipes[prod][key] > availible[key]) {
                    message = `Error: not enough ${key} in stock`
                    break;
                }
            }
        } else if (task == 'report'){
            message = `protein=${availible['protein']} carbohydrate=${availible['carbohydrate']
        }fat=${availible['fat']} flavour=${availible['flavour']}`;
        }
        return message;
    };
    return manager;
}

let manager = solution();
console.log(manager("restock flavour 50")); // Success
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));