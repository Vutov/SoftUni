import React, { Component } from 'react';
import RegisterForm from './RegisterForm';
import { register } from '../../models/user';

export default class RegisterPage extends Component {
    constructor(props) {
        super(props);
        this.state = { username: '', password: '', name: '' };
        this.bindEventHandlers();
    }

    bindEventHandlers() {
        // Make sure event handlers have the correct context
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
        this.onSubmitResponse = this.onSubmitResponse.bind(this);
    }

    onChangeHandler(event) {
        let data = {};
        data[event.target.name] = event.target.value
        this.setState(data);
    }

    onSubmitHandler(event) {
        event.preventDefault();
        register(this.state.username, this.state.password, this.state.name, this.onSubmitResponse);
    }

    onSubmitResponse(response) {
        if (response === true) {
            this.context.router.push('/');
        }
    }

    render() {
        return (
            <RegisterForm
                username={this.state.username}
                password={this.state.password}
                repeat={this.state.repeat}
                onChangeHandler={this.onChangeHandler}
                onSubmitHandler={this.onSubmitHandler}
                />
        );
    }
}

RegisterPage.contextTypes = {
    router: React.PropTypes.object
};