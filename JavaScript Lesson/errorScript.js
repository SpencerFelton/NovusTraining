var txt = "";
function message()
{
  try {
    // delibrate error in aalert
    alert("Welcome to this website");
  }
  catch(err)
  {
    txt="There was an error on this page.\n\n";
    txt += "Error description: " + err.message+ "\n\n";
    txt += "Click OK to continue viewing this page with errors\n";
    txt+="Click Cancel to goto google.co.uk\n\n";
    if(!confirm(txt))
    {
      document.location.href = "http://www.google.co.uk";
    }
  }
}
