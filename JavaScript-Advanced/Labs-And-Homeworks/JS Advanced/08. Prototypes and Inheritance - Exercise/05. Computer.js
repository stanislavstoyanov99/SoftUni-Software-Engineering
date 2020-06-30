function createComputerHierarchy() {
    class Device {
        constructor (manufacturer) {
            if (new.target === Device) {
                throw new Error('Cannot instantiate directly.');
            }

            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Device {
        constructor (manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }

    class Monitor extends Device {
        constructor (manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }

    class Battery extends Device {
        constructor (manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }

    class Computer extends Device {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target === Computer) {
                throw new Error('Cannot instantiate directly.');
            }

            super(manufacturer);
            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }

    class Laptop extends Computer {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);

            this.weight = weight;
            this.color = color;

            if (!(battery instanceof Battery)) {
                throw new TypeError('Cannot instantiate directly.');
            } else {
                this._battery = battery;
            }
        }

        get battery() {
            return this._battery;
        }

        set battery(newBattery) {
            if (!(newBattery instanceof Battery)) {
                throw new TypeError('Cannot instantiate directly.');
            }

            this._battery = newBattery;
        }
    }

    class Desktop extends Computer {
        constructor (manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            
            if (!(keyboard instanceof Keyboard)) {
                throw new TypeError('Cannot instantiate directly.');
            } else {
                this._keyboard = keyboard;
            }

            if (!(monitor instanceof Monitor)) {
                throw new TypeError('Cannot instantiate directly.');
            } else {
                this._monitor = monitor;
            }
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(newKeyboard) {
            if (!(newKeyboard instanceof Keyboard)) {
                throw new TypeError('Cannot instantiate directly.');
            }

            this._keyboard = newKeyboard;
        }

        get monitor() {
            return this._monitor;
        }

        set monitor(newMonitor) {
            if (!(newMonitor instanceof Monitor)) {
                throw new TypeError('Cannot instantiate directly.');
            }

            this._monitor = newMonitor;
        }
    }

    return {
        Device,
        Keyboard,
        Monitor,
        Battery,
        Computer,
        Laptop,
        Desktop
    };
}

let classes = createComputerHierarchy();

let keyboard = new classes.Keyboard('Logitech',70);
let monitor = new classes.Monitor('Benq',28,18);
let desktop = new classes.Desktop("JAR Computers",3.3,8,1,keyboard,monitor);