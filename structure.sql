create table if not exists customers (
    customer_id serial not null primary key,
    firstname varchar(255) not null,
    lastname varchar(255) not null,
    email varchar(255) not null
);

create table if not exists orders (
    order_id serial not null primary key,
    customer_id int not null,
    country varchar(255) not null,
    street varchar(512) not null,
    city varchar(255) not null,
    zip_code varchar(6) not null,
    total decimal(12, 2)  not null,
    foreign key(customer_id) references customers(customer_id)
);

create table if not exists order_items (
    order_item_id serial not null primary key,
    price decimal(12, 2)  not null,
    description varchar(255) not null,
    quantity int not null,
    order_id int not null,
    foreign key(order_id) references orders(order_id)
);
