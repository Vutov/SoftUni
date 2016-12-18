import { get, del, post } from './requester';
import observer from './observer';

function loadUsersMessages(callback) {
    let username = sessionStorage.getItem('username');
    get('appdata', 'messages?query={"recipient_username": "' + username + '"}', 'kinvey')
        .then(callback);
}

function loadSentMessages(callback) {
    let username = sessionStorage.getItem('username');
    get('appdata', 'messages?query={"sender_username": "' + username + '"}', 'kinvey')
        .then(callback);
}

function deleteMessage(id) {
    del('appdata', 'messages/' + id, 'kinvey')
        .then(deleteSuccess);

    function deleteSuccess() {
        observer.showSuccess('Message deleted.');
    }
}

function sendMessage(recipient, text) {
    let name = sessionStorage.getItem('name');
    let username = sessionStorage.getItem('username');
    let data = {
        sender_name: name === undefined ? null : name,
        sender_username: username,
        recipient_username: recipient,
        text: text
    };

    post('appdata', 'messages', data, 'kinvey')
        .then(sendSuccess);

    function sendSuccess() {
        observer.showSuccess('Message sent.');
    }
}

export { loadUsersMessages, loadSentMessages, deleteMessage,sendMessage };