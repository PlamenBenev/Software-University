function attachEventsListeners() {
    let button = document.getElementById('convert');
    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');
    
    button.addEventListener('mousedown', () => {
        let inputNum = Number(document.getElementById('inputDistance').value);
        let outputDistance = document.getElementById('outputDistance');
        let toMeter = 0;
        let inputUnit = inputUnits.value;
        let outputUnit = outputUnits.value;

         if (inputUnit == 'km'){
            toMeter = inputNum * 1000;
         } else if (inputUnit == 'm'){
            toMeter = inputNum;
         } else if (inputUnit == 'cm'){
            toMeter = inputNum * 0.01;
         } else if (inputUnit == 'mm'){
            toMeter = inputNum * 0.001;
         } else if (inputUnit == 'mi'){
            toMeter = inputNum * 1609.34;
         } else if (inputUnit == 'yrd'){
            toMeter = inputNum * 0.9144;
         } else if (inputUnit == 'ft'){
            toMeter = inputNum * 0.3048;
         } else if (inputUnit == 'in'){
            toMeter = inputNum * 0.0254;
         }

         if (outputUnit == 'km'){
            outputDistance.value = toMeter / 1000;
         } else if (outputUnit == 'm'){
            outputDistance.value = toMeter;
         } else if (outputUnit == 'cm'){
            outputDistance.value = toMeter / 0.01;
         } else if (outputUnit == 'mm'){
            outputDistance.value = toMeter / 0.001;
         } else if (outputUnit == 'mi'){
            outputDistance.value = toMeter / 1609.34;
         } else if (outputUnit == 'yrd'){
            outputDistance.value = toMeter / 0.9144;
         } else if (outputUnit == 'ft'){
            outputDistance.value = toMeter / 0.3048;
         } else if (outputUnit == 'in'){
            outputDistance.value = toMeter / 0.0254;
         }
    });
}