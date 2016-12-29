import React, { Component } from 'react';
import { loadProductsForLoggedUser, removeFromCart } from '../../models/products';
import Cart from './Cart';

export default class CartPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: []
        };
    }

    onLoadSuccess(response) {
        this.setState({ products: response })
    }

    componentDidMount() {
        loadProductsForLoggedUser(this.onLoadSuccess.bind(this));
    }

    onRemoveFromCart(id) {
        removeFromCart(id, function (response) {
            if (response === true) {
                loadProductsForLoggedUser(this.onLoadSuccess.bind(this));
            }
        }.bind(this));
    }

    render() {
        return (
            <Cart products={this.state.products} removeFromCart={this.onRemoveFromCart.bind(this)} />
        );
    }
}

CartPage.contextTypes = {
    router: React.PropTypes.object
};