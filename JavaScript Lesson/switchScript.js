function roll(){
  var one = 0;
  var two = 0;
  var three = 0;
  var four = 0;
  var five = 0;
  var six = 0;
  var die = 0;
  var numberOfRolls =parseInt(document.getElementById('dieRoll').value);
  for (var rollDice = 1; rollDice <= numberOfRolls; rollDice++){
    die=Math.floor(1+ Math.random()* 6);
    switch(die){
      case 1:
        ++one;
        document.getElementById('throw_one').innerHTML=one;
        break;
      case 2:
        ++two;
        document.getElementById('throw_two').innerHTML=two;
        break;
      case 3:
        ++three;
        document.getElementById('throw_three').innerHTML=three;
        break;
      case 4:
        ++four;
        document.getElementById('throw_four').innerHTML=four;
        break;
      case 5:
        ++five;
        document.getElementById('throw_five').innerHTML=five;
        break;
      case 6:
        ++six;
        document.getElementById('throw_six').innerHTML=six;
        break;
    }
  }
}
