import React, { Component } from 'react';
import { formatDate, formatSender } from '../../models/formatters';

export default class UsersMessages extends Component {
    render() {
        return (
            <section id="viewMyMessages">
                <h1>My Messages</h1>
                <div className="messages" id="myMessages">
                    <table>
                        <thead>
                            <tr>
                                <th>From</th>
                                <th>Message</th>
                                <th>Date Received</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                this.props.messages.map(function (message) {
                                    return <tr key={message._id}>
                                        <td>{formatSender(message.sender_name, message.sender_username)}</td>
                                        <td>{message.text}</td>
                                        <td>{formatDate(message._kmd.ect)}</td>
                                    </tr>
                                })
                            }
                        </tbody>
                    </table>
                </div>
            </section>
        );
    }
}

