let c = 0;
let count = 0;
async function filterProducts() {
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked)
            checkedCategories.push(allCategoriesOptions[i].value)
    }
    const name = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    document.getElementById("PoductList").replaceChildren([]);
    getBooks(name, minPrice, maxPrice, checkedCategories);
}
async function getBooks(name, minPrice, maxPrice, checkedCategories) {
    let url = `/api/Product`;
    if (name || minPrice || maxPrice || checkedCategories)
        url += `?`
    if (name) url += `name=${name}`;
    if (minPrice) url += `&minPrice=${minPrice}`;
    if (maxPrice) url += `&maxPrice=${maxPrice}`;
    if (checkedCategories) {
        for (let i = 0; i < checkedCategories.length; i++) {
            url += `&categoryIds=${checkedCategories[i]}`
        }
    }

   
    const res = await fetch(url);
    const data = await res.json();
    c = data.length;
    document.getElementById("counter").innerHTML = c;
    console.log(data);
    drawProducts1(data);
}
async function drawProducts() {
    const res = await fetch(`api/Product`);
    const data = await res.json();
    console.log(data)
    c = data.length;
    document.getElementById("counter").innerHTML = c;
    for (let i=0; i < data.length; i++) {
        draw(data[i])
    }
}
async function drawProducts1(data) {
    for (let i = 0; i < data.length; i++) {
        draw(data[i])
    }
}
function draw(prod) {
    var tmpCatg = document.getElementById("temp-card");
    var cln = tmpCatg.content.cloneNode(true);
    cln.querySelector("h1").innerText = prod.name;
    cln.querySelector(".price").innerText = prod.price;
    cln.querySelector("img").src = "./images/" + prod.image;

    cln.querySelector("button").addEventListener('click', () => { addToCart(prod) });
    document.getElementById("PoductList").appendChild(cln);
    document.getElementById("ItemsCountText").innerHTML = count;
}

cart = [];
async function addToCart(prod) {
    count++;
    document.getElementById("ItemsCountText").innerHTML = count;
    cart.push(prod);
    sessionStorage.setItem("MyCart", JSON.stringify(cart));
    sessionStorage.setItem("count", count);
    
}
async function getAllCategory() {
    const res = await fetch("api/category");
    const data = await res.json();
    return data;
}

const showCategories = async () => {
    const Categories = await getAllCategory();
    console.log(Categories);
    const res = await fetch(`api/Product`);
    const data = await res.json();
    console.log(data);
    for (let i = 0; i < Categories.length; i++) {
        var tmpCatg = document.getElementById("temp-category");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector("span.OptionName").innerText = Categories[i].name;
        cln.querySelector(".opt").value = Categories[i].categoryId;
        document.getElementById("categoryList").appendChild(cln);
    }

}