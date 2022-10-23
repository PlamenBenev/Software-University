function solution(input) {
    let result = [];

    input.forEach(element => {
        let [command,string] = element.split(' ');
        if (command == 'add'){
            result.push(string);
        } else if (command == 'remove'){
            result = result.filter(x => x != string);
        } else if (command == 'print'){
            console.log(result.join(','));
        }
    });
}

function add(arg){

}

solution(['add pesho', 'add george', 'add peter', 'remove peter','print']);