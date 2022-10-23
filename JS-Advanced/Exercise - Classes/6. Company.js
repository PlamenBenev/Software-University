class Company {
  constructor() {
    this.departments = {};
    // this.addEmployee(this.name,this.salary,this.position,this.departments);
  }

  addEmployee(name,salary,position,department) {
    if (typeof (name) === 'string' && typeof (salary) === 'number' &&
      typeof (position) === 'string' && typeof (department) === 'string' &&
      salary >= 0) {
      if (this.departments[department] == undefined) {
        this.departments[department] = [{
          name: name,
          salary: salary,
          position: position,
        }];

      } else {
        this.departments[department].push(
          {
            name: name,
            salary: salary,
            position: position,
          }
        );
      }
      return `New employee is hired. Name: ${name}. Position: ${position}`;
    } else {
      throw new Error('Invalid input!');
    }
  }
  bestDepartment() {
    let best;
    for (const department in this.departments) {
      let sum = 0;

      for (const element in this.departments[department]) {
        sum += this.departments[department][element].salary;
      };

      this.departments[department].avrg = (sum / this.departments[department].length).toFixed(2);
      this.departments[department].name = department;

      if (best == undefined || best.avrg < this.departments[department].avrg) {
        best = this.departments[department];
      }
    }

    function compare(a, b) {
      if (a.name < b.name) {
        return -1;
      }
      if (a.name > b.name) {
        return 1;
      }
      return 0;
    }

    best.sort(compare)
    best.sort((a, b) => b.salary - a.salary);
    let arr = [];
    for (let i = 0; i < best.length; i++) {
      arr.push(`${best[i].name} ${best[i].salary} ${best[i].position}`)
    }

    return `Best Department is: ${best.name}\n` +
      `Average salary: ${best.avrg}\n` +
      `${arr.join('\n')}`;
  }
}

let c = new Company();
c.addEmployee("Stanimir", 1000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Suan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());