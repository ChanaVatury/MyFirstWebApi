
async function filterProducts() {
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) checkedCategories.push(allCategoriesOptions[i].id)
    }
    const name = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    getBooks(name, minPrice, maxPrice, checkedCategories);
}
async function getBooks(name, minPrice, maxPrice, checkedCategories) {
    const res = await fetch(`api/Product?name=${name}?minPrice=${minPrice}?maxPrice=${maxPrice}`);
    const data = await res.json();
    console.log(data);
}
async function drawProducts() {
    const res = await fetch(`api/Product`);
    const data = await res.json();
    console.log(data)
    for (let i=0; i < data.length; i++) {
        var tmpCatg = document.getElementById("temp-card");
        var cln = tmpCatg.content.cloneNode(true);
        cln.querySelector("h1").innerText = data[i].name;
        cln.querySelector(".price").innerText = data[i].price;
        cln.querySelector("img").src = "./images/" + data[i].image;
        cln.querySelector("button").addEventListener('click', () => { addToCart(data[i]) });
        document.getElementById("PoductList").appendChild(cln);
    }
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