function solve(...args) {
    let obj = {};
    args.forEach(el => {
        let type = typeof (el);
        console.log(`${typeof (el)}: ${el}`);
        if (!obj.hasOwnProperty(type)) {
            obj[type] = 0;
        }
        obj[type]++;
    })

    Object.entries(obj)
    .sort((a,b) => a - b)
    .forEach(x => console.log(`${x[0]} = ${x[1]}`))

}

solve('cat', 'dog', 42, function () { console.log('Hello world!'); });