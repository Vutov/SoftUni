import React, { Component } from 'react';

export default class LoginForm extends Component {
    render() {
        return (
            <section id="viewLogin">
                <h1>Please login</h1>
                <form id="formLogin" onSubmit={this.props.onSubmitHandler}>
                    <label>
                        <div>Username:</div>
                        <input
                            type="text"
                            name="username"
                            id="loginUsername"
                            value={this.props.username}
                            onChange={this.props.onChangeHandler}
                            required />
                    </label>
                    <label>
                        <div>Password:</div>
                        <input
                            type="password"
                            name="password"
                            id="loginPasswd"
                            value={this.props.password}
                            onChange={this.props.onChangeHandler}
                            required />
                    </label>
                    <div>
                        <input type="submit" value="Login" />
                    </div>
                </form>
            </section>
        );
    }
}