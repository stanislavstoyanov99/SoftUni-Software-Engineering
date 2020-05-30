function printsStars(size) {
    if (size === undefined) {
        size = 5;
    }

    for (let i = 0; i < Number(size); i++) {
        console.log("* ".repeat(size));
    }
}

printsStars();
printsStars(1);
printsStars(2);
printsStars(5);