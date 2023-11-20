
let count = sessionStorage.getItem("count");
let prod = JSON.parse(sessionStorage.getItem("MyCart"));
async function drawProducts() {
 
    for (let i = 0; i < prod.length; i++) {
        console.log(prod[i])
        var tmpCatg = document.getElementById("temp-row");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price;
        cln.querySelector("img").src = "./images/" + prod[i].image;
        cln.querySelector(".totalColumn").addEventListener('click', () => {
            prod.splice(i, 1);
            sessionStorage.setItem("MyCart", prod);
            drawProducts();
        });
        document.getElementById("items").appendChild(cln);
    }
}

 

