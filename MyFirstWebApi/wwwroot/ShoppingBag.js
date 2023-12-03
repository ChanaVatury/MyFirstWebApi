
let count = sessionStorage.getItem("count");
let prod = JSON.parse(sessionStorage.getItem("MyCart"));
let c = 0;
//let count2 = prod.length;
class OrderItem{
    constructor(UserId, Quantity) {
        this.UserId = UserId;
        this.Quantity = Quantity;
    }
}
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

    console.log(sessionStorage.getItem("CurrentUser"));
    if (sessionStorage.getItem("CurrentUser") == null)
        window.location.href = "./home.html";

    let orderItems = [];
    for (let i = 0; i < prod.length; i++) {
        let UserId = prod[i].id
        let Quantity = 0
        orderItems[i] = new OrderItem(UserId, Quantity)
    }


    let order = {
        orderDate : new Date(),
        orderSum: c,
        userId: JSON.parse(sessionStorage.getItem("CurrentUser")).userId,
        ordersItems: orderItems
    };
 
    const res = await fetch("api/order/", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    })

    //if (!res.ok)
    //    throw new Error("error in adding your details to our site")

    let data = await res.json();
    alert(`your order ${data.orderId} get successfully`)
    
 
}