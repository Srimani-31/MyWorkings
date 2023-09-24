import React, { Component } from 'react'

export default class Counter extends Component {

    constructor(){
        super()
        this.state = {
            count : 0
        }
    }
    increamentFive(){
      this.increament()
      this.increament()
      this.increament()
      this.increament()
      this.increament()
    }
    increament(){
      this.setState(
        (prevState) => ({
          count: prevState.count +1
        })
      )
    }
      
  render() {
    return (
      <div>
          <h3>Count : {this.state.count}</h3>
          <button onClick={() => this.increamentFive()}>Increament by five</button><br></br>
          <code>Use always function to change the state inside setState() method instead direct property change</code>
      </div>
    )
  }
}
