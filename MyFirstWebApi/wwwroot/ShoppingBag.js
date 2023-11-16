
let count = sessionStorage.getItem("count");
async function drawProducts() {
    for (let i = 0; i < count; i++) {
        draw(sessionStorage.getItem("MyCart")[i+2])
    }
}

function draw(prod) {
    var tmpCatg = document.getElementById("temp-card");
    var cln = tmpCatg.content.cloneNode(true);
    cln.querySelector(".price").innerText = prod.price;
    cln.querySelector("imageColumn").src = "./images/" + prod.image;
    document.getElementById("PoductList").appendChild(cln);
}
