import React, { Component } from 'react';
import '../../components/common/Form.css'

export default class RegisterForm extends Component {
    render() {
        return (
            <section id="viewRegister">
                <h1>Please register here</h1>
                <form id="formRegister" onSubmit={this.props.onSubmitHandler}>
                    <label>
                        <div>Username:</div>
                        <input
                            type="text"
                            name="username"
                            id="registerUsername"
                            value={this.props.username}
                            onChange={this.props.onChangeHandler}
                            required />
                    </label>
                    <label>
                        <div>Password:</div>
                        <input
                            type="password"
                            name="password"
                            id="registerPasswd"
                            value={this.props.password}
                            onChange={this.props.onChangeHandler}
                            required />
                    </label>
                    <label>
                        <div>Name:</div>
                        <input
                            type="text"
                            name="name"
                            id="registerName"
                            value={this.props.repeat}
                            onChange={this.props.onChangeHandler} />
                    </label>
                    <div>
                        <input type="submit" value="Register"/>
                    </div>
                </form>
            </section>
        );
    }
}