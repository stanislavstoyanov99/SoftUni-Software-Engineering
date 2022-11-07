abstract class Employee {
    public tasks: string[];
    private name: string;
    private age: number;
    private salary: number;

    constructor (name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    public work(): void {
        let currentTask = this.tasks.shift();
        this.tasks.push(currentTask ?? '');
        console.log(this.name + currentTask);
    }

    public collectSalary(): void {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    public getSalary(): number {
        return this.salary;
    }
}

class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks.push(" is working on a simple task");
    }
}

class Senior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks.push(" is working on a complicated task.");
        this.tasks.push(" is taking time off work.");
        this.tasks.push(" is supervising junior workers.");
    }
}

class Manager extends Employee {
    private divident: number;

    constructor(name: string, age: number) {
        super(name, age);
        this.divident = 0;
        this.tasks.push(" scheduled a meeting.");
        this.tasks.push(" is preparing a quarterly report.");
    }

    public getSalary(): number {
        return this.getSalary() + this.divident;
    }
}