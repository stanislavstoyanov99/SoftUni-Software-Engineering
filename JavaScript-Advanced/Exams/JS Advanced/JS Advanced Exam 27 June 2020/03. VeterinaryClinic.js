class VeterinaryClinic {
    registrator = {};

    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.totalProfit = 0;
        this.currentWorkload = 0;
        this.clients = [];
    }

    newCustomer(ownerName, petName, kind, procedures) {
        const clientsCount = this.clients.length;

        if (clientsCount > this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        if (!(ownerName in this.registrator)) {
            this.registrator[ownerName] = [];
        }

        const foundPet = this.registrator[ownerName].find(x => x.petName === petName);

        if (foundPet && foundPet.procedures.length !== 0) {
            throw new Error(`This pet is already registered under ${ownerName} name! ${foundPet.petName} is on our lists, waiting for ${foundPet.procedures.join(', ')}.`);
        } else {
            this.registrator[ownerName].push({petName, kind, procedures});
            this.clients.push(ownerName);
            this.currentWorkload++;

            return `Welcome ${petName}!`;
        }
    }

    onLeaving(ownerName, petName) {
        const owner = this.clients.find(x => x === ownerName);

        if (!owner) {
            throw new Error('Sorry, there is no such client!');
        }

        const ownerPet = this.registrator[ownerName].find(x => x.petName === petName);
        
        if (!ownerPet || ownerPet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${ownerPet.petName}!`);
        }

        const currentOwnerBill = ownerPet.procedures.length * 500;
        this.totalProfit += currentOwnerBill;
        this.currentWorkload--;
        ownerPet.procedures = [];

        return `Goodbye ${ownerPet.petName}. Stay safe!`;
    }

    toString() {
        let outputMessage = '';
        
        const totalPets = Object.entries(this.registrator)
            .filter(([key, value]) => value.filter(pet => pet.procedures.length !== 0))
            .reduce((acc, curr) => {
                acc += 1;
                return acc;
            }, 0);

        const percentageBusinnes = Math.round(totalPets * 100 / this.capacity);
        outputMessage += `${this.clinicName} is ${percentageBusinnes}% busy today!\n`;

        outputMessage += `Total profit: ${this.totalProfit.toFixed(2)}$\n`;

        const sortedRegistrator = Object.entries(this.registrator)
            .sort((a, b) => a[0].localeCompare(b[0]));

        sortedRegistrator.forEach(([owner, value]) => {
            value.forEach(pet => {
                outputMessage += `${owner} with:\n` + `---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(', ')}\n`;
            });
        });

        return outputMessage.trimEnd();
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
