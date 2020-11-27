function addNumbers() {
  var num1 = document.getElementById("num1").value;
  var num11 = parseInt(num1);
  var num2 = document.getElementById("num2").value;
  var num22 = parseInt(num2);
  var num3 = document.getElementById("num3").value;
  var num33 = parseInt(num3);
  var sum = num11 + num22 + num33;
  document.getElementById("answer").innerHTML = sum;
  return sum;
}

function subNumbers() {
  var num1 = document.getElementById("sub1").value;
  var num11 = parseInt(num1);
  var num2 = document.getElementById("sub2").value;
  var num22 = parseInt(num2);
  var num3 = document.getElementById("sub3").value;
  var num33 = parseInt(num3);
  var sum = num11 - num22 - num33;
  document.getElementById("subanswer").innerHTML = sum;
  return sum;
}
