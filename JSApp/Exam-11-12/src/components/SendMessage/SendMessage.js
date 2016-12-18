import React, { Component } from 'react';
import { formatSender } from '../../models/formatters';

export default class SentMessages extends Component {
    render() {
        return (
            <section id="viewSendMessage">
                <h1>Send Message</h1>
                <form id="formSendMessage" onSubmit={this.props.onSubmitHandler}>
                    <div>Recipient:</div>
                    <div>
                        <select
                            name="recipient"
                            onChange={this.props.onChangeHandler}
                            required
                            id="msgRecipientUsername">
                            {
                                this.props.users.map(function (user) {
                                    return <option key={user._id} value={user.username}>{formatSender(user.name, user.username)}</option>
                                })
                            }
                        </select>
                    </div>
                    <div>Message Text:</div>
                    <div><input
                        type="text"
                        name="text"
                        required
                        onChange={this.props.onChangeHandler}
                        id="msgText" /></div>
                    <div><input type="submit" value="Send" /></div>
                </form>
            </section>
        );
    }
}