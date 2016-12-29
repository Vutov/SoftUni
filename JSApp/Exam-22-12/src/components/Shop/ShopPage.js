import React, { Component } from 'react';
import { loadAllProducts, addToCart } from '../../models/products';
import Shop from './Shop'

export default class ShopPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            products: []
        };
    }

    onLoadSuccess(response) {
        this.setState({ products: response })
    }

    onAddToCart(id) {
        addToCart(id, function (response) {
            if (response === true) {
                this.context.router.push('/cart');
            }
        }.bind(this));
    }

    componentDidMount() {
        loadAllProducts(this.onLoadSuccess.bind(this));
    }

    render() {
        return (
            <Shop products={this.state.products} addToCart={this.onAddToCart.bind(this)} />
        );
    }
}

ShopPage.contextTypes = {
    router: React.PropTypes.object
};