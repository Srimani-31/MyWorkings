import React, { Component } from 'react';

class SideEffectMaintainanceViaClass extends Component {
    constructor(props) {
        super(props);
        this.state = {
            clickCount: 0,
        };
    }
    
    componentDidMount() {
        console.log('componentDidMount');
        document.title = `You clicked ${this.state.clickCount} times`
    }

    componentDidUpdate() {
        console.log('componentDidUpdate');
        document.title = `You clicked ${this.state.clickCount} times`

    }

    componentWillUnmount() {
        console.log('componentWillUnmount');
        document.title = `You clicked ${this.state.clickCount} times`

    }
    render() {
        return (
            <div>
                <h3>Component life cycle in class component</h3>
                <button onClick={() => this.setState({ clickCount: this.state.clickCount + 1 })}>
                    {this.state.clickCount} Clicks so far
                </button>
            </div>
        );
    }
}


export default SideEffectMaintainanceViaClass


