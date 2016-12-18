import React, { Component } from 'react';
import $ from 'jquery';
import observer from '../../models/observer';

export default class Infobox extends Component {
    constructor(props) {
        super(props);
        this.state = {
            message: '',
            type: 'loading',
            visible: false
        };

        observer.showLoading = this.showLoading.bind(this);
        observer.showSuccess = this.showSuccess.bind(this);
        observer.showError = this.showError.bind(this);
    }

    componentDidMount() {
        $(document).on({
            ajaxStart: function () {
                this.setState({ message: 'Loading...', type: 'loading', visible: true })
            }.bind(this),
            ajaxStop: function (){
                if( this.state.type === 'loading'){
                    this.hide();
                }
            }.bind(this),
            ajaxError: function (e, response) {
                let errorMsg = JSON.stringify(response);
                if (response.readyState === 0)
                    errorMsg = "Cannot connect due to network error.";
                if (response.responseJSON && response.responseJSON.description)
                    errorMsg = response.responseJSON.description;
                this.showError(errorMsg);
            }.bind(this)
        });
    }

    hide() {
        this.setState({ visible: false });
    }

    showLoading(message) {
        this.setState({ message: message, type: 'loading', visible: true });
    }

    showSuccess(message) {
        this.setState({ message: message, type: 'success', visible: true });
        setTimeout(this.hide.bind(this), 3000);
    }

    showError(errorMsg) {
        this.setState({ message: errorMsg, type: 'error', visible: true });
    }

    render() {
        if (!this.state.visible) return null;

        let className = '';
        switch (this.state.type) {
            case 'loading':
                className += 'loadingBox';
                break;
            case 'error':
                className += 'errorBox';
                break;
            case 'success':
                className += 'infoBox';
                break;
            default:
                break;
        }

        return (
            <div id={className} onClick={this.hide.bind(this)}>
                {this.state.message}
            </div>
        )
    }
}
