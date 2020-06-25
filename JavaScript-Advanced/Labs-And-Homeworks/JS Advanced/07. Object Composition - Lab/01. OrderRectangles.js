function createObject(inputArray) {
    const rectanglePrototype = {
        area() {
            return this.height * this.width;
        },
        compareTo(other) {
            const currArea = this.area();
            const otherArea = other.area();

            return otherArea - currArea || other.width - this.width;
        }
    }

    function createRectangle(width, height) {
        const rectangle = Object.create(rectanglePrototype);

        rectangle.width = width;
        rectangle.height = height;

        return rectangle;
    }

    return inputArray.reduce((acc, curr) => {
        const [width, height] = curr;
        const rectangle = createRectangle(width, height);

        return acc.concat(rectangle);
    }, [])
        .sort((a, b) => a.compareTo(b));
}

const input = [[10,5], [5,12]];
console.log(createObject(input));