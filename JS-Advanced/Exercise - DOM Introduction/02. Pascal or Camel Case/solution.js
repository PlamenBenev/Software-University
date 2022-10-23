function solve() {
  let theText = document.getElementById('text').value.toLowerCase();
  let namingConvention = document.getElementById('naming-convention').value;
  let result = document.getElementById('result');
  let arr = theText.split(' ');

  if (namingConvention == 'Camel Case'){
    for (let i = 1; i < arr.length; i++) {
      arr[i] = arr[i][0].toUpperCase() + arr[i].slice(0);
    }
    result.textContent = arr.join('');
  } else if (namingConvention == 'Pascal Case'){
    for (let i = 0; i < arr.length; i++) {
      arr[i] = arr[i][0].toUpperCase() + arr[i].slice(0);
    }
    result.textContent = arr.join('');
  } else {
    result.textContent = 'Error!';
  }
  console.log(arr);
}