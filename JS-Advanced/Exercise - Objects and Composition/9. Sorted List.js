function createSortedList() {
    const list = {
        theList: [],
        add(param){
            let adding = this.theList.push(param);
            return adding;
        },
        get(param){ 
            let getter = this.theList[param];
            return getter;
        },
        remove(param){
            let remover = this.theList.splice(param,param);
            return remover;
        }
    }

    return list;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1); 
console.log(list.get(1));