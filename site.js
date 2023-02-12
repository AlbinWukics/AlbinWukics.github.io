const productOne = document.querySelector("#products");

const products = [
  { id: "1", cost: 40, image: "bilder/brödprodukt1.webp" },
  { id: "2", cost: 50, image: "bilder/brödprodukt2.webp" },
  { id: "3", cost: 30, image: "bilder/brödprodukt3.webp" },
  { id: "4", cost: 20, image: "bilder/brödprodukt4.webp" },
];

displayProducts();

function displayProducts() {
  for (const product of products) {
    const column = document.createElement("div");
    const image = document.createElement("img");
    const headerCost = document.createElement("h3");
    const addToCartBtn = document.createElement("button");

    column.classList.add("col", "text-center");
    image.src = product.image;
    image.alt = `bröd produkt ${product.id}`;
    image.classList.add("img-fluid");
    headerCost.classList.add("mt-2");
    headerCost.innerText = `${product.cost} kr`;
    addToCartBtn.type = "button";
    addToCartBtn.classList.add("btn", "btn-outline-info", "btn-lg", "mt-2");
    addToCartBtn.innerText = "Lägg till i varukorg";

    column.append(image, headerCost, addToCartBtn);
    productOne.appendChild(column);
  }
}
