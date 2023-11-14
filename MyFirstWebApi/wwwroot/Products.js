
async function filterProducts() {
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) checkedCategories.push(allCategoriesOptions[i].id)
    }
    const name = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    document.getElementById("PoductList").replaceChildren([]);
    getBooks(name, minPrice, maxPrice, checkedCategories);
}
async function getBooks(name, minPrice, maxPrice, checkedCategories) {
    let url = `api/Product?name=${name}?minPrice=${minPrice}?maxPrice=${maxPrice}`;
    for (let i = 0; i < checkedCategories.length; i++) {
        url += `&categoryIds=${checkedCategories[i]}`;
    }
    const res = await fetch(url);
    const data = await res.json();
    console.log(data);
}
async function drawProducts() {
    const res = await fetch(`api/Product`);
    const data = await res.json();
    console.log(data)
    for (let i=0; i < data.length; i++) {
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
}
async function addToCart() {

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
        document.getElementById("categoryList").appendChild(cln);
    }

}