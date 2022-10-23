class Person{
    constructor(firstname,lastname,age,email){
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
        this.email = email;
    }

    toString(){
        return `${this.firstname} ${this.lastname} (age: ${this.age}, email: ${this.email})`;
    }
}

let person = new Person('gosho','peshov','15','goshopeshov@abv.bg');

console.log(person.toString());