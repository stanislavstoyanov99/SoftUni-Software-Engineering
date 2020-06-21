function focus() {
    function focusIn(e) {
        const target = e.target;
        const { parentElement: { classList } } = target;
        classList.add('focused');
    }

    function focusOut(e) {
        const target = e.target;
        const { parentElement: { classList } } = target;
        classList.remove('focused');
    }

    const inputFields = [...document.querySelectorAll('input[type="text"]')];
    inputFields.forEach(x => x.addEventListener('focus', focusIn));
    inputFields.forEach(x => x.addEventListener('blur', focusOut));
}