import React, { Component } from 'react';
import { formatPrice } from '../../models/formatters';

export default class Cart extends Component {
    render() {
        return (
            <section id="viewCart">
                <h1>My Cart</h1>
                <div className="products" id="cartProducts">
                    <table>
                        <thead>
                            <tr>
                                <th>Product</th>
                                <th>Description</th>
                                <th>Quantity</th>
                                <th>Total Price</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.props.products.map(function (product) {
                                    return <tr key={product._id}>
                                        <td>{product.name}</td>
                                        <td>{product.description}</td>
                                        <td>{product.quantity}</td>
                                        <td>{formatPrice(product.price * product.quantity)}</td>
                                        <td><button onClick={this.props.removeFromCart.bind(this, product._id)}>Discard</button></td>
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

