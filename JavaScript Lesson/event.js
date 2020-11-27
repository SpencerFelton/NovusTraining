/*
The Function
define the thing you want to happen */
function clickAbout() {
alert('You clicked on about');
}

function clickArticle() {
alert('you clicked on article!');
}

function clickCopy() {
alert('you clicked on copyright!');
}

/*
The Variable
get the element you want to do it on */
var element1 = document.getElementById("about");
var element2 = document.getElementById("article");
var element3 = document.getElementById("copy");
/*
The Event Listener
set up something to listen for the event you want, then execute the
function */
element1.addEventListener('click', clickAbout, false);
element2.addEventListener('click', clickArticle, false);
element3.addEventListener('click', clickCopy, false);
