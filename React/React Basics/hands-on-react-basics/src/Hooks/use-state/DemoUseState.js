import React from 'react'
import ClassCounter from './ClassCounter'
import HookCounter from './HookCounter'
import HookCounterTwo from './HookCounterTwo'
import HookCounterThree from './HookCounterThree'
function DemoUseState() {
  return (
    <div>
        <h3>State Management in React</h3>
      <ClassCounter /><br></br>
      <HookCounter />
      <HookCounterTwo />
      <HookCounterThree />
    </div>
  )
}

export default DemoUseState;
