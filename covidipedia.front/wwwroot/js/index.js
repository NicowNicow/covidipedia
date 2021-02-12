document.getElementById('checkbox-sales-countries').onchange = function(){
  var salesCountries = document.getElementsByClassName('sales-countries')[0];
  if (this.checked) salesCountries.classList.remove('hide');
  else salesCountries.classList.add('hide');
}

document.getElementById('checkbox-discount-countries').onchange = function(){
  var salesCountries = document.getElementsByClassName('discount-countries')[0];
  if (this.checked) salesCountries.classList.remove('hide');
  else salesCountries.classList.add('hide');
}

document.getElementById('checkbox-profit-month').onchange = function(){
  var salesCountries = document.getElementsByClassName('profit-month')[0];
  if (this.checked) salesCountries.classList.remove('hide');
  else salesCountries.classList.add('hide');
}