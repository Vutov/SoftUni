import React, { Component } from 'react';
import { formatDate } from '../../models/formatters';

export default class SentMessages extends Component {
    render() {
        return (
            <section id="viewArchiveSent">
                <h1>Archive (Sent Messages)</h1>
                <div className="messages" id="sentMessages">
                    <table>
                        <thead>
                            <tr>
                                <th>To</th>
                                <th>Message</th>
                                <th>Date Sent</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.props.messages.map(function (message) {
                                    return <tr key={message._id}>
                                        <td>{message.recipient_username}</td>
                                        <td>{message.text}</td>
                                        <td>{formatDate(message._kmd.ect)}</td>
                                        <td><button onClick={this.props.deleteMessage.bind(this, message._id)}>Delete</button></td>
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

