import React, { Component } from 'react'

export class ClassCounter extends Component {
    constructor() {
        super()
        this.state = {
            count: 0
        }
    }

    increamentCounter = () => {
        this.setState({
            count: this.state.count + 1
        })
    }
    render() {
        return (
            <div>
                <h3>State management using class component</h3>
                <button onClick={this.increamentCounter}>Count {this.state.count}</button>
            </div>
        )
    }
}

export default ClassCounter

//checklist to be followed to maintain state

//1. Create a component
//2. Create a State property and initialize it
//3. Create a function that set the status for the property
