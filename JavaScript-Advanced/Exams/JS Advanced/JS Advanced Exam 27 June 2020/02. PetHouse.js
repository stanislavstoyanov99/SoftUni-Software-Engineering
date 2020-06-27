function solveClasses() {
    class Pet {
        constructor(owner, name) {
            this.owner = owner;
            this.name = name;
            this.comments = [];
        }

        addComment(comment) {
            const foundComment = this.comments.find(x => x === comment);

            if (foundComment) {
                throw new Error('This comment is already added!');
            }

            this.comments.push(comment);

            return 'Comment is added.';
        }

        feed() {
            return `${this.name} is fed`;
        }

        toString() {
            let output = `Here is ${this.owner}'s pet ${this.name}.\n`;

            if (this.comments.length !== 0) {
                output += `Special requirements: ${this.comments.join(', ')}`;
            }

            return output.trimEnd();
        }
    }

    class Cat extends Pet {
        constructor(owner, name, insideHabits, scratching) {
            super(owner, name);
            this.insideHabits = insideHabits;
            this.scratching = scratching;
        }

        feed() {
            return super.feed() + ', happy and purring.';
        }

        toString() {
            let output = super.toString() + '\n';

            output += `Main information:\n${this.name} is a cat with ${this.insideHabits}`;

            if (this.scratching) {
                output += `, but beware of scratches.`;
            }

            return output.trimEnd();
        }
    }

    class Dog extends Pet {
        constructor(owner, name, runningNeeds, trainability) {
            super(owner, name);
            this.runningNeeds = runningNeeds;
            this.trainability = trainability;
        }

        feed() {
            return super.feed() + ', happy and wagging tail.';
        }

        toString() {
            let output = super.toString() + '\n' + 'Main information:\n';
            output += `${this.name} is a dog with need of ${this.runningNeeds}km running every day and ${this.trainability} trainability.`;

            return output.trimEnd();
        }
    }

    return {
        Pet,
        Cat,
        Dog
    };
}

let classes = solveClasses();
let dog = new classes.Dog('Susan', 'Max', 5, 'good');     

console.log(dog.addComment('likes to be brushed'));
console.log(dog.addComment('sleeps a lot'));
console.log(dog.feed());
console.log(dog.toString());


