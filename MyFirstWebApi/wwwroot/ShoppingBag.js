
let count = sessionStorage.getItem("count");
let prod = JSON.parse(sessionStorage.getItem("MyCart"));
let c = 0;
//let count2 = prod.length;

async function drawProducts() {
    document.getElementById("itemCount").innerHTML = prod.length;
    c = 0;
    for (let i = 0; i < prod.length; i++) {
        c += prod[i].price;
    }
    document.getElementById("totalAmount").innerHTML = c;
    for (let i = 0; i < prod.length; i++) {
        console.log(prod[i])
        var tmpCatg = document.getElementById("temp-row");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price;
        cln.querySelector("img").src = "./images/" + prod[i].image;
        cln.querySelector(".totalColumn").addEventListener('click', () => deletFromCart(prod[i]));
        document.getElementById("h").appendChild(cln);
    }
}

async function deletFromCart(prod1) {
    prod = prod.filter(c => c != prod1);
    sessionStorage.setItem("MyCart", JSON.stringify(prod));
    document.getElementById("h").replaceChildren([]);
    drawProducts();
}

async function placeOrder() {
    let order = {
        orderDate : new Date(),
        orderSum: c,
        userId: JSON.parse(sessionStorage.getItem("CurrentUser")).userId,
        ordersItems:prod
    };
 
    const res = await fetch("api/order/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    })

    if (!res.ok)
        throw new Error("error in adding your details to our site")

    let data = await res.json();
    alert(`your order ${data.orderId}`)
    
 
}




