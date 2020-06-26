function classHierarchy() {
    class Figure {
        constructor(unit = 'cm') {
            this.unit = unit;
            this.converterFromCm = {
                m: (number) => number / 100,
                cm: (number) => number,
                mm: (number) => number * 10
            };
        }

        changeUnits(newUnit) {
            this.unit = newUnit;
        }

        toString() {
            return `Figures units: ${this.unit}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, unit) {
            super(unit);
            this.radius = radius;
        }

        get area() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return Math.PI * convert(this.radius) * convert(this.radius);
        }

        toString() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return `${super.toString()} Area: ${this.area} - radius: ${convert(this.radius)}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, unit) {
            super(unit);
            this.width = width;
            this.height = height;
        }

        get area() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return convert(this.width) * convert(this.height);
        }

        toString() {
            const convert = (number) => this.converterFromCm[this.unit](number);
            return `${super.toString()} Area: ${this.area} - width: ${convert(this.width)}, height: ${convert(this.height)}`;
        }
    }

    let c = new Circle(5);
    console.log(c.area); // 78.53981633974483
    console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

    let r = new Rectangle(3, 4, 'mm');
    console.log(r.area); // 1200 
    console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

    r.changeUnits('cm');
    console.log(r.area); // 12
    console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

    c.changeUnits('mm');
    console.log(c.area); // 7853.981633974483
    console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50

    return {
        Figure,
        Circle,
        Rectangle
    };
}

classHierarchy();