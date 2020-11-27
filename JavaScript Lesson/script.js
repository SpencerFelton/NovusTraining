//using getElementById and innerHTML
function loop(){

  var loopVar = document.getElementById('loopTimes').value;
  //alert(loopVar);
  //convert variable to integer
  var loopNumber = parseInt(loopVar,10);
  //alert(loopNumber);
  for (c = 0; c < loopNumber ; c++){
    var text1 = ("The counter is currently " + c) + ("<br />");
    // write into the p tag
    document.getElementById("text").innerHTML += text1;
  }
}
