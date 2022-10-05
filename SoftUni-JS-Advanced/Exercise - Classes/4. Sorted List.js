class List {
  constructor() {
    this.list = [].sort();
    this.size = this.list.length;
  }

  add(element){
    this.list.push(element);
  }
  remove(index){
    this.list.splice(index,index);
  }
  get(index){
    return this.list[index];
  }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));