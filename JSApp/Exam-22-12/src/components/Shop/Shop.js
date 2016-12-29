import React, { Component } from 'react';
import { formatPrice } from '../../models/formatters';

export default class Shop extends Component {
    render() {
        return (
            <section id="viewShop">
                <h1>Products</h1>
                <div className="products" id="shopProducts">
                    <table>
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Description</th>
                                <th>Price</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.props.products.map(function (product) {
                                    return <tr key={product._id}>
                                        <td>{product.name}</td>
                                        <td>{product.description}</td>
                                        <td>{formatPrice(product.price)}</td>
                                        <td><button onClick={this.props.addToCart.bind(this, product._id)}>Purchase</button></td>
                                    </tr>
                                }.bind(this))
                            }
                        </tbody>
                    </table>
                </div>
            </section>
        );
    }
}

