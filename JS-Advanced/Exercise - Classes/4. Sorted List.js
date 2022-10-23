class List {
  constructor() {
    this.list = [];
    this.size = 0;
  }

  add(element){
    this.list.push(element);
    this.size++;
    this.list.sort((a, b) => a - b);
  }
  remove(index){
    if (index >= 0 && index < this.list.length) {
      this.list.splice(index,1);
      this.size--;
      this.list.sort((a, b) => a - b);
    }
  }
  get(index){
    if (index >= 0 && index < this.list.length)  {
      return this.list[index];
    }
  }
}

let list = new List();
list.add(5);
list.add(3);
list.remove(0);
console.log(list.get(0));
