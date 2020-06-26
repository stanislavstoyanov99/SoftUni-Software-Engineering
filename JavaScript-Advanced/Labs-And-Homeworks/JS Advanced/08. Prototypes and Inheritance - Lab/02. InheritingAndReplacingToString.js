function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            const className = Object.getPrototypeOf(this).constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            let parentToString = super.toString();
            parentToString = manipulateToString(parentToString);

            return `${parentToString}, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            let parentToString = super.toString();
            parentToString = manipulateToString(parentToString);

            return `${parentToString}, course: ${this.course})`;
        }
    }

    function manipulateToString(parentToString) {
        return parentToString = parentToString.substr(0, parentToString.length - 1);
    }

    return {
        Person,
        Teacher,
        Student
    };
}