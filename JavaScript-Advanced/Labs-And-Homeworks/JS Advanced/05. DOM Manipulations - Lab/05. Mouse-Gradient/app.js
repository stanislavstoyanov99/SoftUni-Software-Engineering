function attachGradientEvents() {
    const gradient = document.querySelector('#gradient');
    const result = document.querySelector('#result');

    function gradientMove(e) {
        let power = e.offsetX / (e.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        result.textContent = power.toString().concat('%');
    }

    function gradientOut() {
        result.textContent = "";
    }

    gradient.addEventListener('mousemove', gradientMove);
    gradient.addEventListener('mouseout', gradientOut);
}