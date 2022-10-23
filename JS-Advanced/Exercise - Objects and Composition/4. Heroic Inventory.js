function result(param) {
    let heroes = [];

    for (const item of param) {
        let hero = param.shift();
        let [name, level, itemsString] = hero.split(' / ');
        level = Number(level);
        const items = itemsString ? itemsString.split(', ') : [];

        heroes.push({name, level, items});
    }

    return JSON.stringify(heroes);
}

console.log(result(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']));