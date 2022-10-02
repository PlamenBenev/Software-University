function solve(in1,in2) {
    let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A']
    let suits = {
        H: '\u2665',
        D: '\u2666',
        S: '\u2660',
        C: '\u2663'
    }
    // ['\u2660','\u2663','\u2665','\u2666']

    if (faces.includes(in1) && in1 == in1.toUpperCase() && in2 == in2.toUpperCase()){
        let card = {
            face: in1,
            suit: suits[in2],
            toString: function () {
                return `${this.face}${this.suit}`;
            }
        };
        return card;
    } else {
        throw new Error('Error');
    }
}

console.log(solve('A','S'));
console.log(solve('10', 'H'));
console.log(solve('1', 'S'));