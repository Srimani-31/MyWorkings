import React, { useState } from 'react'

function HookCounter() {
    const initialCount = 0
    const [currentCount, setCount] = useState(initialCount)
    return (
        <div>
            <h3>Demonstration of UseState() Hook</h3>
            <button onClick={() => setCount(currentCount + 1)}>Count {currentCount}</button>
        </div>
    )
}

export default HookCounter


//create a function component
//import useState hook
//useState() accepts initial value of the state property/object
//returns array of size two
//1. the current value of the state property/object
//2. method to set the status of the property

