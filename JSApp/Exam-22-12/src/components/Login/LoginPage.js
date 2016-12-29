import React, { Component } from 'react';
import LoginForm from './LoginForm';
import { login } from '../../models/user';

export default class LoginPage extends Component {
    constructor(props) {
        super(props);
        this.state = { username: '', password: '' };
        this.bindEventHandlers();
    }

    bindEventHandlers() {
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
        login(this.state.username, this.state.password, this.onSubmitResponse);
    }

    onSubmitResponse(response) {
        if (response === true) {
            this.context.router.push('/');
        } 
    }

    render() {
        return (
            <LoginForm
                username={this.state.username}
                password={this.state.password}
                onChangeHandler={this.onChangeHandler}
                onSubmitHandler={this.onSubmitHandler}
                />
        );
    }
}

LoginPage.contextTypes = {
    router: React.PropTypes.object
};