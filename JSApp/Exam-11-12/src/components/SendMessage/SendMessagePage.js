import React, { Component } from 'react';
import SendMessage from './SendMessage';
import { loadUsers } from '../../models/user';
import { sendMessage } from '../../models/messages';

export default class SendMessagePage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            users: [],
            text: '',
            recipient: ''
        };
    }

    onLoadSuccess(response) {
        this.setState({ users: response, recipient: response[0].username })
    }

    componentDidMount() {
        loadUsers(this.onLoadSuccess.bind(this));
    }

    onChangeHandler(event) {
        let data = {};
        data[event.target.name] = event.target.value
        this.setState(data);
    }

    onSubmitHandler(event) {
        event.preventDefault();
        sendMessage(this.state.recipient, this.state.text);
    }

    render() {
        return (
            <SendMessage
                users={this.state.users}
                onChangeHandler={this.onChangeHandler.bind(this)}
                onSubmitHandler={this.onSubmitHandler.bind(this)}
                />
        );
    }
}

SendMessagePage.contextTypes = {
    router: React.PropTypes.object
};