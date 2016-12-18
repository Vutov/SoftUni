import React, { Component } from 'react';
import UsersMessages from './UsersMessages';
import { loadUsersMessages } from '../../models/messages';

export default class UsersMessagesPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            messages: []
        };
    }

    onLoadSuccess(response) {
        this.setState({ messages: response })
    }

    componentDidMount() {
        loadUsersMessages(this.onLoadSuccess.bind(this));
    }

    render() {
        return (
            <UsersMessages messages={this.state.messages} />
        );
    }
}

UsersMessagesPage.contextTypes = {
    router: React.PropTypes.object
};