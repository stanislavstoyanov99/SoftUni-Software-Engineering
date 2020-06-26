class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer({firstName, lastName, personalId}) {
        const doesItExist = this.allCustomers.some(x => x.firstName === firstName && x.lastName === lastName);

        if (doesItExist) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        const customer = { firstName, lastName, personalId };
        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        const customer = this.allCustomers.find(x => x.personalId === Number(personalId));

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        const amountToDeposit = Number(amount);

        if (!customer.hasOwnProperty('totalMoney')) {
            customer.totalMoney = amountToDeposit;
            customer.transactions = [];
        }
        else {
            customer.totalMoney += amountToDeposit;
        }

        customer.transactions.push({type: 'deposit', value: amount});

        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        const customer = this.allCustomers.find(x => x.personalId === Number(personalId));

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        const amountToWithdraw = Number(amount);

        if (customer.totalMoney - amountToWithdraw < 0) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amountToWithdraw;
        customer.transactions.push({type: 'withdrew', value: amount});
        
        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        const customer = this.allCustomers.find(x => x.personalId === Number(personalId));

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        const {firstName, lastName, totalMoney, transactions} = customer;

        let outputResult = `Bank name: ${this._bankName}\n`;

        outputResult += `Customer name: ${firstName} ${lastName}\n` + `Customer ID: ${personalId}\n`
            + `Total Money: ${totalMoney}$\n`;

        outputResult += 'Transactions:\n';

        let count = transactions.length;
        for (let i = transactions.length - 1; i >= 0; i--) {
            const transactionType = transactions[i].type;

            if (transactionType === 'deposit') {
                outputResult += `${count}. ${firstName} ${lastName} made deposit of ${transactions[i].value}$!\n`;
            } else {
                outputResult += `${count}. ${firstName} ${lastName} withdrew ${transactions[i].value}$!\n`;
            }
            
            count--;
        }

        // Clever way, not my solution
        // output += customer.transactions[personalId].reduceRight((acc, amount, index) => {
        //     acc += amount > 0
        //         ? `${index + 1}. ${firstName} ${lastName} made deposit of ${amount}$!\n`
        //         : `${index + 1}. ${firstName} ${lastName} withdrew ${Math.abs(amount)}$!\n`;

        //     return acc;
        // }, "")

        return outputResult.trimEnd();
    }
}


let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({firstName: "Svetlin", lastName: "Nakov", personalId: 1111111}));
console.log(bank.newCustomer({firstName: "Mihaela", lastName: "Mileva", personalId: 4151596}));

bank.depositMoney(1111111, 250);
console.log(bank.depositMoney(1111111, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(1111111, 125));
console.log(bank.customerInfo(1111111));