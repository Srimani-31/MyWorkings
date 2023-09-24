import React, { Component } from './react';

class AddingChildElement extends Component {
    render(props) {
        return (
            <>
                <h1>This is {this.props.friendName}</h1>
                {this.props.children}
            </>

        )
    }
}
export default AddingChildElement;