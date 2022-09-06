 function asd(arrinput,start,end){
    let array = [];
    let result = [];
    let startIndex;
    let endIndex;

    for (var item of arrinput) {
        array.push(item)
    }
    for (let index = 0; index < array.length; index++) {
       if (array[index] == start){
        startIndex = index;
       }
       if (array[index] == end){
        endIndex = index;
       }
    }
    for (let i = startIndex; i <= endIndex; i++) {
        result.push(array[i]);
    }
    console.log(result);
}
asd(['Apple Crisp', 'Mississippi Mud Pie', 'Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie'], 'Pot Pie', 'Smoked Fish Pie');
