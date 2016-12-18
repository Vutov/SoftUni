import React, { Component } from 'react';
import SentMessages from './SentMessages';
import { loadSentMessages, deleteMessage } from '../../models/messages';

export default class SentMessagesPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            messages: []
        };
    }

    onLoadSuccess(response) {
        this.setState({ messages: response })
    }

    deleteMessage(id) {
        deleteMessage.call(this, id);
        loadSentMessages(this.onLoadSuccess.bind(this));
    }

    componentDidMount() {
        loadSentMessages(this.onLoadSuccess.bind(this));
    }

    render() {
        return (
            <SentMessages messages={this.state.messages} deleteMessage={this.deleteMessage.bind(this)} />
        );
    }
}

SentMessagesPage.contextTypes = {
    router: React.PropTypes.object
};