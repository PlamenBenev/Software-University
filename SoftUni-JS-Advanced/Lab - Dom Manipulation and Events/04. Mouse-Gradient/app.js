function attachGradientEvents() {
    let hoverer = document.getElementById('gradient');
    let result = document.getElementById('result');

    const hover = (e) => {
        let percent = (e.offsetX / e.target.offsetWidth) * 100
        result.textContent = Math.floor(percent);
    }
    hoverer.addEventListener('mousemove', hover);
   // result.textContent = hover;
}