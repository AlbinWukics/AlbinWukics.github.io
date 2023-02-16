const productManager = document.querySelector("#productsId");
const cartManager = document.querySelector("#cartId");

const products = [
  {
    id: "1",
    quantityInCart: 0,
    name: "Runt bröd",
    cost: 40,
    image: "bilder/brödprodukt1.webp",
  },
  {
    id: "2",
    quantityInCart: 0,
    name: "Längre bröd",
    cost: 50,
    image: "bilder/brödprodukt2.webp",
  },
  {
    id: "3",
    quantityInCart: 0,
    name: "Churros",
    cost: 30,
    image: "bilder/brödprodukt3.webp",
  },
  {
    id: "4",
    quantityInCart: 0,
    name: "Konstiga kanelbullar",
    cost: 20,
    image: "bilder/brödprodukt4.webp",
  },
];

displayProducts();

function displayProducts() {
  for (const product of products) {
    const column = document.createElement("div");
    const image = document.createElement("img");
    const headerName = document.createElement("h5");
    const headerCost = document.createElement("h5");
    const addToCartBtn = document.createElement("button");
    const removeFromCartBtn = document.createElement("button");

    column.classList.add("col", "text-center");
    image.src = product.image;
    image.alt = `Produkt ${product.id}`;
    image.classList.add("img-fluid");
    image.setAttribute("height", "300px");
    image.setAttribute("width", "300px");
    headerName.classList.add("mt-2");
    headerName.innerText = product.name;
    headerCost.classList.add("mt-2");
    headerCost.innerText = `${product.cost} kr`;

    addToCartBtn.type = "button";
    addToCartBtn.classList.add("btn", "btn-outline-info", "btn-lg", "mt-2");
    addToCartBtn.onclick = function () {
      product.quantityInCart++;
      displayCart();
    };
    addToCartBtn.innerText = "Lägg till i varukorg";

    removeFromCartBtn.type = "button";
    removeFromCartBtn.classList.add(
      "btn",
      "btn-outline-danger",
      "btn-lg",
      "mt-2",
      "ms-2"
    );
    removeFromCartBtn.onclick = function () {
      if (product.quantityInCart < 1) return;
      product.quantityInCart--;
      displayCart();
    };
    removeFromCartBtn.innerText = "-";

    column.append(
      image,
      headerName,
      headerCost,
      addToCartBtn,
      removeFromCartBtn
    );
    productManager.appendChild(column);
  }
}

function displayCart() {
  const existingDuplicationProtection = document.querySelector("#duplicated");
  if (existingDuplicationProtection) {
    cartManager.removeChild(existingDuplicationProtection);
  }

  let totalCost = 0;
  const duplicationProtectionParent = document.createElement("div");
  duplicationProtectionParent.id = "duplicated";

  const firstColumn = document.createElement("div");
  firstColumn.classList.add("col-4", "ms-4");

  for (const product of products) {
    if (product.quantityInCart == 0) continue;

    const productinfo = document.createElement("h5");

    productinfo.classList.add("mt-2");
    totalCost += product.quantityInCart * product.cost;
    productinfo.innerText = `${product.name} x${product.quantityInCart} = ${
      product.quantityInCart * product.cost
    } kr`;

    firstColumn.append(productinfo);
  }

  const secondColumn = document.createElement("div");
  secondColumn.classList.add("col");
  const totalCostView = document.createElement("h4");
  totalCostView.innerText = `Totalt ${totalCost} kr`;
  secondColumn.append(totalCostView);

  duplicationProtectionParent.append(firstColumn, secondColumn);
  cartManager.appendChild(duplicationProtectionParent);
}
