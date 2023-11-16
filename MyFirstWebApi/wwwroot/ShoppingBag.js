
let count = sessionStorage.getItem("count");
async function drawProducts() {
    let prod = JSON.parse(draw(sessionStorage.getItem("MyCart")));
    for (let i = 0; i < prod.length; i++) {
        var tmpCatg = document.getElementById("temp-card");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod.price;
        cln.querySelector("imageColumn").src = "./images/" + prod.image;
        document.getElementById("PoductList").appendChild(cln);
    }
}

