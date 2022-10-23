function solve() {
  let textArea = document.getElementById('input').value.split('.').map(x => x.trim()).filter(x => x);
  let output = document.getElementById('output');

  let triples = [];
  let result = [];

  for (let i = 0; i < textArea.length; i++) {
    triples.push(textArea[i]);
    if (triples.length == 3){
      result.push(`<p> ${triples.join('. ')} </p>`);
      triples = [];
    }
    else if (i == textArea.length - 1 && triples.length != 3){
      result.push(`<p> ${triples.join('. ')} </p>`);
    }
  }
  output.innerHTML = result;
}