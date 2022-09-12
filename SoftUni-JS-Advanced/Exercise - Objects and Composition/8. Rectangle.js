function rectangle(fparam,sparam,color) {
    let upper = color.charAt(0).toUpperCase() + color.slice(1);
    const rect = {
        width: fparam,
        height: sparam,
        color: upper,
        calcArea() {
          let calc =  this.width * this.height;
          return calc;
        }
    }
    return rect;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());