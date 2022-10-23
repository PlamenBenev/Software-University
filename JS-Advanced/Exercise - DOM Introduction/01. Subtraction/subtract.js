function subtract() {
    let result = document.getElementById('result');
    let num1 = document.getElementById('firstNumber').value;
    let num2 = document.getElementById('secondNumber').value;

    result.textContent = Number(num1) - Number(num2);
}