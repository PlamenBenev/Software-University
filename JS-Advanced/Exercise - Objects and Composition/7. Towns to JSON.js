function result(param) {
    const output = [];

    for (let i = 1; i < param.length; i++) {
        let spliter = param[i].split("|");
        
        let ob = {
            Town: spliter[1].trim(), 
            Latitude: Number(spliter[2]).toFixed(2), 
            Longitude: Number(spliter[3]).toFixed(2)
        }
            ob.Latitude = Number(ob.Latitude);
            ob.Longitude = Number(ob.Longitude);
            output.push(ob);
    }

    return JSON.stringify(output);
}

console.log(result(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']));