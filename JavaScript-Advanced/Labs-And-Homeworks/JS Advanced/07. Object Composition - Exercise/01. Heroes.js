function solve() {
    const fighterProto = {
        fight
    };

    function fight() {
        this.stamina--;
        console.log(`${this.name} slashes at the foe!`);
    }

    const mageProto = {
        cast
    };

    function cast(spell) {
        this.mana--;
        console.log(`${this.name} cast ${spell}`);   
    }

    function fighter(name) {
        const fighterInstace = Object.create(fighterProto);
        
        Object.assign(fighterInstace, {
            name,
            health: 100,
            stamina: 100
        });

        return fighterInstace;
    }

    function mage(name) {
        const mageInstance = Object.create(mageProto);

        Object.assign(mageInstance, {
            name,
            health: 100,
            mana: 100
        });

        return mageInstance;
    }

    return {mage: mage, fighter: fighter};
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight();

console.log(scorcher2.stamina);
console.log(scorcher.mana);
