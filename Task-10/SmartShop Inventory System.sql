
USE SmartShop;

CREATE TABLE categories
(
    category_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

CREATE TABLE suppliers
(
    supplier_id INT PRIMARY KEY,
    name VARCHAR(150) NOT NULL,
    contact_email VARCHAR(100)
);

CREATE TABLE products
(
    product_id INT PRIMARY KEY,
    name VARCHAR(200) NOT NULL,
    price DECIMAL(10,2) NOT NULL,
    category_id INT REFERENCES categories(category_id),
    supplier_id INT REFERENCES suppliers(supplier_id)
);

CREATE TABLE inventory
(
    inventory_id INT PRIMARY KEY,
    product_id INT REFERENCES products(product_id),
    stock_level INT NOT NULL,
    restock_date DATE
);

CREATE TABLE sales
(
    sale_id INT PRIMARY KEY,
    product_id INT REFERENCES products(product_id),
    quantity INT NOT NULL,
    sale_date DATETIME NOT NULL
);



SELECT
    p.product_id,
    p.name,
    p.price,
    i.stock_level
FROM
    products AS p
    JOIN
    inventory AS i
    ON p.product_id = i.product_id;



SELECT
    p.name,
    p.price,
    i.stock_level
FROM
    products AS p
    JOIN
    inventory AS i
    ON p.product_id = i.product_id
WHERE
  p.category_id = 3 -- example category ID
    AND i.stock_level > 0;
-- only available products




SELECT
    p.name,
    p.price,
    i.stock_level
FROM
    products AS p
    JOIN
    inventory AS i
    ON p.product_id = i.product_id
WHERE
  i.stock_level > 0
ORDER BY
  p.name ASC,              -- alphabetical
  i.stock_level DESC;      -- highest stock first
