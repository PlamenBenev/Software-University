function factory(library, orders) {
    const result = [];
    for (let order of orders) {
        const composed = Object.assign({}, order.template);
        for (let part of order.parts) {
            composed[part] = library[part];
        }

        result.push(composed)
    }
    return result;
}

function factory2(library, orders) {
    const result = orders.map(order => {
        const composed = Object.assign({}, order.template);
        for (let part of order.parts) {
            composed[part] = library[part];
        }
        return composed;
    })
    return result
}

const library = {
    print: function () {
        console.log(`${this.name} is printing a page`);
    },
    scan: function () {
        console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
        console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
};
const orders = [
    {
        template: {name: 'ACME Printer'},
        parts: ['print']
    },
    {
        template: {name: 'Initech Scanner'},
        parts: ['scan']
    },
    {
        template: {name: 'ComTron Copier'},
        parts: ['scan', 'print']
    },
    {
        template: {name: 'BoomBox Stereo'},
        parts: ['play']
    },
];
const products = factory(library, orders);
console.log(products);