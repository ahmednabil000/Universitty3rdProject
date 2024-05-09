const apiUrl = '../javascript/test.json';

fetch(apiUrl)
  .then(response => {
    if (response.ok) {
      return response.json();
    }
    throw new Error('Network response was not ok.');
  })
  .then(data => {
    console.log('Data from the API:', data);
  })
  .catch(error => {
    console.error('Error fetching data:', error);
  });

  var parantCard=document.getElementById("images");
  function createCard(Name,URL) {
    var Card=document.createElement("div");
    var btn =document.createElement("button");
    var spn =document.createElement("span");
    Card.classList.add("CardDiv")
    btn.classList.add("cardbutton")
    Card.style.backgroundImage = `url('${URL}')`;
    spn.innerText=Name;
    btn.appendChild(spn);
    Card.appendChild(btn);
    parantCard.appendChild(Card)
  }

  createCard("BAGUETTE","../images/Template/image\ \(24\).jpg");
  createCard("PAIN AU CHOCOLAT","../images/Template/image\ \(4\).jpg");
  createCard("PAIN","../images/Template/image\ \(14\).jpg");
  createCard("TRADITIONAL BAGUETTE","../images/Template/image\ \(19\).jpg");
  createCard("CROISSANT","../images/Template/image\ \(15\).jpg");
  createCard("BANETTE","../images/Template/image\ \(30\).jpg");
  createCard("BANETTINE","../images/Template/image\ \(16\).jpg");
  createCard("SPECIAL BREAD","../images/Template/image\ \(6\).jpg");
  createCard("COUPE","../images/Template/image\ \(37\).jpg");

var product1 = document.getElementById('div1').style.backgroundImage = "url('../images/Template/image\ \(24\).jpg')";
var product2 = document.getElementById('div2').style.backgroundImage = "url('../images/Template/image\ \(4\).jpg')";
var product3 = document.getElementById('div3').style.backgroundImage = "url('../images/Template/image\ \(14\).jpg')";
var product4 = document.getElementById('div4').style.backgroundImage = "url('../images/Template/image\ \(19\).jpg')";
var product5 = document.getElementById('div5').style.backgroundImage = "url('../images/Template/image\ \(15\).jpg')";
var product6 = document.getElementById('div6').style.backgroundImage = "url('../images/Template/image\ \(30\).jpg')";
var product7 = document.getElementById('div7').style.backgroundImage = "url('../images/Template/image\ \(16\).jpg')";
var product8 = document.getElementById('div8').style.backgroundImage = "url('../images/Template/image\ \(6\).jpg')";
var product9 = document.getElementById('div9').style.backgroundImage = "url('../images/Template/image\ \(37\).jpg')";
sessionStorage.setItem("product1", JSON.stringify(product1));
sessionStorage.setItem("product2", JSON.stringify(product2));
sessionStorage.setItem("product3", JSON.stringify(product3));
sessionStorage.setItem("product4", JSON.stringify(product4));
sessionStorage.setItem("product5", JSON.stringify(product5));
sessionStorage.setItem("product6", JSON.stringify(product6));
sessionStorage.setItem("product7", JSON.stringify(product7));
sessionStorage.setItem("product8", JSON.stringify(product8));
sessionStorage.setItem("product9", JSON.stringify(product9));
var btn1 = document.getElementById('p1');
var btn2 = document.getElementById('p2');
var btn3 = document.getElementById('p3');
var btn4 = document.getElementById('p4');
var btn5 = document.getElementById('p5');
var btn6 = document.getElementById('p6');
var btn7 = document.getElementById('p7');
var btn8 = document.getElementById('p8');
var btn9 = document.getElementById('p9');
var p = btn1.addEventListener("click",chooseProduct());
function chooseProduct() {
    if(btn1.id === 'p1') {
        sessionStorage.setItem("product1", JSON.stringify(product1));
        // sessionStorage.setItem("p1", JSON.stringify('p1'));
    }
    if(btn.id === 'p2') {
        sessionStorage.setItem("p2", JSON.stringify('p2'));
    }
    if('p3') {
        sessionStorage.setItem("p3", JSON.stringify('p3'));
    }
    if('p4') {
        sessionStorage.setItem("p4", JSON.stringify('p4'));
    }
    if('p5') {
        sessionStorage.setItem("p5", JSON.stringify('p5'));
    }
    if('p6') {
        sessionStorage.setItem("p6", JSON.stringify('p6'));
    }
    if('p7') {
        sessionStorage.setItem("p7", JSON.stringify('p7'));
    }
    if('p8') {
        sessionStorage.setItem("p8", JSON.stringify('p8'));
    }
    if('p9') {
        sessionStorage.setItem("p9", JSON.stringify('p9'));
    }
}
