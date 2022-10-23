function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstname = firstName;
            this.lastname = lastName;
            this.age = age;
            this.email = email;
        }

        toString() {
            return `${this.firstname} ${this.lastname} (age: ${this.age}, email: ${this.email})`;
        }
    }


    let person = [new Person('Anna', 'Simpson', '22', 'anna@yahoo.com'),
    new Person('SoftUni'),
    new Person('Stephan', 'Johnson', '25'),
    new Person('Gabriel', 'Peterson', '24', 'g.p@gmail.com')];

    return person;
}
console.log(getPersons()[0].lastname);