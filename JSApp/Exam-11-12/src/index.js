import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import {IndexRoute, Router, Route, browserHistory} from 'react-router';
import HomePage from './components/Home/HomePage';
import Login from './components/Login/LoginPage';
import Register from './components/Register/RegisterPage';
import Logout from './components/Logout/LogoutPage';
import UsersMessages from './components/UsersMessages/UsersMessagesPage';
import SentMessages from './components/SentMessages/SentMessagesPage';
import SendMessage from './components/SendMessage/SendMessagePage';

ReactDOM.render(
    <Router history={browserHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={HomePage}/>
            <Route path="login" component={Login}/>
            <Route path="register" component={Register}/>
            <Route path="logout" component={Logout}/>
            <Route path="mymessages" component={UsersMessages}/>
            <Route path="archive" component={SentMessages}/>
            <Route path="sendmessage" component={SendMessage}/>
        </Route>
    </Router>,
    document.getElementById('root')
);
