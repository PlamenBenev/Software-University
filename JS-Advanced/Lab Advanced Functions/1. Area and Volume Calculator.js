function area() {
    return Math.abs(this.x * this.y);
};
function vol() {
    return Math.abs(this.x * this.y * this.z);
};

function solve(area, vol, cordinates) {
    let parsing = JSON.parse(cordinates);
    let result = [];

    for (const axis of parsing) {
        result.push({
            area: area.call(axis),
            vol: vol.call(axis)
        });
    }

    console.log(result);
}
solve(area, vol, `[

    {"x":"1","y":"2","z":"10"},
    
    {"x":"7","y":"7","z":"10"},
    
    {"x":"5","y":"2","z":"10"}
    
    ]`);