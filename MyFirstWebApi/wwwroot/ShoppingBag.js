
let count = sessionStorage.getItem("count");
let prod = JSON.parse(sessionStorage.getItem("MyCart"));
//let count2 = prod.length;

async function drawProducts() { 
    document.getElementById("itemCount").innerHTML = count;
    for (let i = 0; i < prod.length; i++) {
        console.log(prod[i])
        var tmpCatg = document.getElementById("temp-row");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price;
        cln.querySelector("img").src = "./images/" + prod[i].image;
        cln.querySelector(".totalColumn").addEventListener('click', () => deletFromCart(prod[i]));
        document.getElementById("items").appendChild(cln);
    }
}

async function deletFromCart(prod1) {
    prod = prod.filter(c => c != prod1);
    sessionStorage.removeItem("MyCart");
    sessionStorage.setItem("MyCart", JSON.stringify(prod));
    document.getElementById("items").replaceChildren([]);
    drawProducts();
}

 

