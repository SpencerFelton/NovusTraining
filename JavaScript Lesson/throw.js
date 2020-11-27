function getNumber()
{
  var num = parseInt(document.getElementById("myNumber").value);
  try{
    if(num>5)
    {
      throw("Number is greater than 5");
    } else if (isNaN(num))
    {
      throw("You did not enter a number!!");
    }
  }
  catch(err)
  {
    alert("error message: " + err);
  }
  finally
  {
    alert("You entered: "+ num);
  }
}
