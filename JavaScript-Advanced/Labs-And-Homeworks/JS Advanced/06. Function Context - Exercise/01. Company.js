class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (username && salary > 0 && position && department) {
            let foundDepartment = this.departments.find(x => x.name === department);

            if (!foundDepartment) {
                foundDepartment = {
                    name: department,
                    employees: []
                };

                this.departments.push(foundDepartment);
            }

            const employee = { username, salary, position, department };
            foundDepartment.employees.push(employee);
            
            return `New employee is hired. Name: ${username}. Position: ${position}`;
        }

        throw new Error('Invalid input!');
    }

    bestDepartment() {
        const bestDepartment = this.departments.sort((a, b) => b.salary - a.salary)[0];
        const totalSalary = bestDepartment.employees.map(x => x.salary).reduce((a, b) => a + b, 0);
        const averageSalary = totalSalary / bestDepartment.employees.length;

        const sortedEmployees = bestDepartment.employees
            .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));
            
        let employesResult = '';
        
        sortedEmployees.forEach(employee => {
            employesResult += `${employee.username} ${employee.salary} ${employee.position}\n`;
        })

        let output = `Best Department is: ${bestDepartment.name}\n` 
            + `Average salary: ${averageSalary.toFixed(2)}\n` 
            + employesResult;
        
        return output.trimEnd();
    }
}

let company = new Company();

company.addEmployee("Stanimir", 2000, "engineer", "Construction");
company.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
company.addEmployee("Slavi", 500, "dyer", "Construction");
company.addEmployee("Stan", 2000, "architect", "Construction");
company.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
company.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
company.addEmployee("Gosho", 1350, "HR", "Human resources");

console.log(company.bestDepartment());

