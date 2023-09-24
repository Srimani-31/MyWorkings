import React, { Component } from 'react';
import Stopwatch from './StopWatch';
class Message extends Component {
  constructor() {
    super()
    this.state = {
      attendanceStatus: 'Check-in',
      stopwatchStarted: false,
      stopwatch: new Stopwatch(),
      timer: null,
      elapsedTime: null,
      checkedOut: false
    }

  }
  render() {
    return (
      <div>
        <button onClick={() => this.changeStatus()}>{this.state.attendanceStatus}</button>
        {this.state.stopwatchStarted && <h1>Getting into work mode</h1>}
        {this.state.elapsedTime !== null &&
          <>
            <h1>Time for rest</h1>
            <h3>Your working hours : {this.state.elapsedTime}</h3>

          </>

        }
      </div>
    )
  }
  changeStatus() {
    if (this.state.attendanceStatus === "Check-in") {
      this.setState({ attendanceStatus: 'Check-out', stopwatchStarted: true, timer: Date.now(), checkedOut: false })
    }
    else {
      const getElapsedTime = Date.now() - this.state.timer;
      const formatedGetElpasedTime = this.formatElapsedTime(getElapsedTime);
      this.setState({ attendanceStatus: 'Check-in', stopwatchStarted: false, elapsedTime: formatedGetElpasedTime })
      setTimeout(() => {
        this.setState({ elapsedTime: null, timer: null, checkedOut: true })
      }, 5000)
    }
  }
  resetStatus() {
    this.setState({ elapsedTime: null, timer: null })
  }

  formatElapsedTime(elapsedTime) {

    const hours = Math.floor(elapsedTime / 3600000);
    const mins = Math.floor((elapsedTime % 3600000) / 60000);
    const secs = Math.floor(((elapsedTime % 3600000) % 60000) / 1000);

    const formattedTime = `${hours.toString().padStart(2, '0')}:${mins.toString().padStart(2, '0')}:${secs.toString().padStart(2, '0')}`;

    return formattedTime;
  }
}

export default Message;

