
let count = sessionStorage.getItem("count");
async function drawProducts() {
    let prod = JSON.parse(sessionStorage.getItem("MyCart"));
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

async function deleteProd(prod) {

}

