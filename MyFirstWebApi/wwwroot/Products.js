

async function filterProducts() {
    const name = document.getElementById("nameSearch").value;
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const res = await fetch(`api/Product?name=${name}?minPrice=${minPrice}?maxPrice=${maxPrice}`);
    const data = await res.json();
    console.log(data);

}

async function drawProducts(prod) {




}