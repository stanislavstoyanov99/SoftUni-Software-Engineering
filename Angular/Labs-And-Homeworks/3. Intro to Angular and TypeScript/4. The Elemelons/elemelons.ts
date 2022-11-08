abstract class Melon {
    public weight: number;
    public melonSort: string;

    constructor (weight: number, melonSort: string) {
        this.weight = weight;
        this.melonSort = melonSort;
    }
}

class Watermelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }

    public elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public toString(): string {
        return `Element: Water\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex()}`;
    }
}

class Firemelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }

    public elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public toString(): string {
        return `Element: Fire\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex()}`;
    }
}

class Earthmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }

    public elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public toString(): string {
        return `Element: Earth\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex()}`;
    }
}

class Airmelon extends Melon {
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }

    public elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public toString(): string {
        return `Element: Air\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex()}`;
    }
}

class Melolemonmelon extends Watermelon {
    public elements: string[];

    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.elements = ['Water', 'Fire', 'Earth', 'Air'];
    }

    public elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    public morph(): Melolemonmelon {
        let elementToShift = this.elements.shift() ?? '';
        this.elements.push(elementToShift);
        return this;
    }

    public toString(): string {
        return `Element: ${this.elements[0]}\nSort: ${this.melonSort}\nElement Index: ${this.elementIndex()}`;
    }
}

// Throws error
// let test : Melon = new Melon(100, "Test");

let watermelon: Watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());