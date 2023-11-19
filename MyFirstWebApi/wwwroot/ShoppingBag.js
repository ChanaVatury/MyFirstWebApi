
let count = sessionStorage.getItem("count");
let prod = JSON.parse(sessionStorage.getItem("MyCart"));
async function drawProducts() {
 
    for (let i = 0; i < prod.length; i++) {
        console.log(prod[i])
        var tmpCatg = document.getElementById("temp-row");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price;
        cln.querySelector("img").src = "./images/" + prod[i].image;
        cln.querySelector(".totalColumn").addEventListener('click', () => { deleteProd(prod[i]) });
        document.getElementById("items").appendChild(cln);
    }
}

async function deleteProd(pro) {
    let p = prod;
    prod = [];
    for (let i = 0; i < p.length; i++) {
        if (p[i].id == p.id) {
            prod.push(p[i])
        }
    }
    sessionStorage.setItem("MyCart", p);
    let prod = JSON.parse(sessionStorage.getItem("MyCart"));
    drawProducts();
}

