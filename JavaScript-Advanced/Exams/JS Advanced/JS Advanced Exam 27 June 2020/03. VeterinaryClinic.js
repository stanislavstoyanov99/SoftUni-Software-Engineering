class VeterinaryClinic {
    registrator = {};

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;

        this._totalProfit = 0;
        this.currentWorkload = 0;

        this.clients = [];
    }

    newCustomer(ownerName, petName, kind, procedures) {
        const clientsCount = this.clients.length;

        if (clientsCount >= this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        if (!(ownerName in this.registrator)) {
            this.registrator[ownerName] = [];
        }

        const foundPet = this.registrator[ownerName].find(x => x.petName == petName);

        if (foundPet && foundPet.procedures.length !== 0) {
            throw new Error(`This pet is already registered under ${ownerName} name!` + 
                ` ${foundPet.petName} is on our lists, waiting for ${foundPet.procedures.join(', ')}.`);
        }

        this.registrator[ownerName].push({ petName, kind, procedures });
        this.clients.push(ownerName);
        this.currentWorkload++;

        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        const owner = this.clients.find(x => x == ownerName);

        if (!owner) {
            throw new Error('Sorry, there is no such client!');
        }

        const ownerPet = this.registrator[ownerName].find(x => x.petName == petName);

        if (!ownerPet || ownerPet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        const currentOwnerBill = ownerPet.procedures.length * 500;
        this._totalProfit += currentOwnerBill;
        this.currentWorkload--;
        ownerPet.procedures.length = 0;

        return `Goodbye ${ownerPet.petName}. Stay safe!`;
    }

    toString() {
        const allPets = Object.values(this.registrator);

        const petsWithProceduresCount = allPets
            .map(obj => obj.filter(p => p.procedures.length !== 0))
            .reduce((acc, curr) => {
                acc += curr.length;
                return acc;
            }, 0);

        const outputMessage = [];
        const percentageBusinnes = Math.floor(petsWithProceduresCount * 100 / this.capacity);
        outputMessage.push(`${this.clinicName} is ${percentageBusinnes}% busy today!`);

        const totalProfit = this._totalProfit.toFixed(2);
        outputMessage.push(`Total profit: ${totalProfit}$`);

        const sortedRegistrator = Object.entries(this.registrator)
            .sort((a, b) => a[0].localeCompare(b[0]));

        sortedRegistrator.forEach(([owner, pets]) => {
            outputMessage.push(`${owner} with:`);

            const sortedPets = pets.sort((a, b) => a.petName.localeCompare(b.petName));

            sortedPets.forEach(pet => {
                outputMessage.push(`---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(', ')}`);
            });
        });

        return outputMessage.join('\n');
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());