function solve() {
    const canFight = (profile) => ({
        fight: () => {
            profile.stamina--;
            console.log(`${profile.name} slashes at the foe!`);
        }
    });

    const canCast = (profile) => ({
        cast: (spell) => {
            profile.mana--;
            console.log(`${profile.name} cast ${spell}`);
        }
    });

    const fighter = (name) => {
        let profile = {
            name,
            health: 100,
            stamina: 100
        };

        return Object.assign(profile, canFight(profile));
    };

    const mage = (name) => {
        let profile = {
            name,
            health: 100,
            mana: 100
        };

        return Object.assign(profile, canCast(profile));
    };

    return {mage: mage, fighter: fighter};
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
