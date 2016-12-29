import { forIn } from 'lodash'
import { get } from './requester';
import { getUserData, updateUser } from './user';
import observer from './observer';

function loadAllProducts(callback) {
    get('appdata', 'products', 'kinvey')
        .then(callback);
}

function addToCart(id, callback) {
    getUserData(function (response) {
        let userData = response;

        getProduct(id, function (response) {
            let product = response[0];

            let updatedData = addProduct(userData, product);

            updateUser(updatedData, function (response) {
                observer.showSuccess('Product purchased.');
                callback(true);
            });
        });
    });
}

function removeFromCart(id, callback){
    getUserData(function (response) {
        let userData = response;

        getProduct(id, function (response) {
            let product = response[0];

            let updatedData = removeProduct(userData, product);

            updateUser(updatedData, function (response) {
                observer.showSuccess('Product discarded.');
                callback(true);
            });
        });
    });
}

function addProduct(userData, product) {
    let id = product._id;
    if (userData.cart === undefined) {
        userData.cart = {};
    }

    if (userData.cart[id]) {
        userData.cart[id].quantity = Number(userData.cart[id].quantity) + 1;
        return userData;
    }

    userData.cart[id] = {
        product: {
            name: product.name,
            description: product.description,
            price: product.price
        },
        quantity: 1
    }

    return userData;
}

function removeProduct(userData, product) {
    let id = product._id;
    if (userData.cart === undefined) {
        userData.cart = {};
    }

    if (userData.cart[id]) {
        delete userData.cart[id];
    }

    return userData;
}

function getProduct(id, callback) {
    get('appdata', 'products?query={"_id": "' + id + '"}', 'kinvey')
        .then(callback);
}

function loadProductsForLoggedUser(callback) {
    getUserData(function (response) {
        if (response.cart === undefined) {
            response.cart = {};
        }

        let products = [];
        forIn(response.cart, function(val, key){
            products.push({
                _id: key,
                name: val.product.name,
                description: val.product.description,
                price: val.product.price,
                quantity: val.quantity
            });
        });

        callback(products);
    });
}

export { loadAllProducts, addToCart, loadProductsForLoggedUser, removeFromCart };