import {get, post} from './requester';
import observer from './observer';

function saveSession(userInfo) {
    let userAuth = userInfo._kmd.authtoken;
    sessionStorage.setItem('authToken', userAuth);
    let userId = userInfo._id;
    sessionStorage.setItem('userId', userId);
    let username = userInfo.username;
    sessionStorage.setItem('username', username);
    let name = userInfo.name;
    sessionStorage.setItem('name', name);

    observer.onSessionUpdate();
}

// user/login
function login(username, password, callback) {
    let userData = {
        username,
        password
    };

    post('user', 'login', userData, 'basic')
        .then(loginSuccess);

    function loginSuccess(userInfo) {
        saveSession(userInfo);
        observer.showSuccess('Login successful.');
        callback(true);
    }
}

// user/register
function register(username, password, name, callback) {
    let userData = {
        name,
        username,
        password
    };

    post('user', '', userData, 'basic')
        .then(registerSuccess);

    function registerSuccess(userInfo) {
        observer.showSuccess('User registration successful.');
        saveSession(userInfo);
        callback(true);
    }
}

// user/logout
function logout(callback) {
    post('user', '_logout', null, 'kinvey')
        .then(logoutSuccess);

    function logoutSuccess(response) {
        observer.showSuccess('Logout successful.');
        sessionStorage.clear();
        observer.onSessionUpdate();
        callback(true);
    }
}

function loadUsers(callback){
    get('user', '', 'kinvey')
        .then(callback);
}

export {login, register, logout, loadUsers};