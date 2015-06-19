CREATE DATABASE online_shop;

USE online_shop;

CREATE TABLE users(
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    username nvarchar(25) UNIQUE NOT NULL,
    full_name nvarchar(50) NULL,
    phone_number nvarchar(20) NULL,
    web_site nvarchar(20) NULL
);

CREATE TABLE products(
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    title nvarchar(50) UNIQUE NOT NULL,
    description nvarchar(250) NULL,
    price decimal NOT NULL
);

CREATE TABLE categories(
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name nvarchar(30) UNIQUE NOT NULL
);

CREATE TABLE reviews(
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    content nvarchar(250) NOT NULL,
    product_id int NOT NULL,
    user_id int NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE shoping_baskets(
	id int PRIMARY KEY AUTO_INCREMENT NOT NULL
);

CREATE TABLE baskets_products(
	basket_id int,
    product_id int,
    PRIMARY KEY (basket_id, product_id),
    FOREiGN KEY (basket_id) REFERENCES shoping_baskets(id),
    FOREiGN KEY (product_id) REFERENCES products(id)
);

ALTER TABLE users ADD basket_id int NOT NULL;
ALTER TABLE users ADD FOREIGN KEY (basket_id) REFERENCES shoping_baskets(id);

ALTER TABLE products ADD category_id int NOT NULL;
ALTER TABLE products ADD FOREIGN KEY (category_id) REFERENCES categories(id);