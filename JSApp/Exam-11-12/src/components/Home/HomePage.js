import React, { Component } from 'react';
import { Link } from 'react-router';

export default class HomePage extends Component {
    constructor(props) {
        super(props);
        this.state = { user: sessionStorage.getItem('username') };
    }

    render() {
        if (this.state.user) {
            return (
                <section id="viewUserHome">
                    <h1 id="viewUserHomeHeading">Welcome, {this.state.user}!</h1>
                    <Link to="/mymessages" id="linkUserHomeMyMessages">My Messages</Link>
                    <Link to="/sendmessage" id="linkUserHomeSendMessage">Send Message</Link>
                    <Link to="/archive" id="linkUserHomeArchiveSent">Archive (Sent)</Link>
                </section>
            )
        } else {
            return (
                <section id="viewAppHome">
                    <h1>Welcome</h1>
                    Welcome to our messaging system.
                </section>
            );
        }
    }
}