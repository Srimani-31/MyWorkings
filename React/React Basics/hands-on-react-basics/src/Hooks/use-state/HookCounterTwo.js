import React from 'react';
import {useState} from 'react';
function HookCounterTwo() {
    const initialCount = 0
    const [currentCount, setCount] = useState(initialCount)

    const increamentByFive = () =>{
        for(var i = 0; i<5;i++)
        {
            setCount(prevState => prevState + 1)
        }
    }
    const decreament = () => {
        if (currentCount > 0 )
            setCount(prevState => prevState - 1)
    }
  return (
    <div>
        <h3>Passing function as parameter instead of direct modifying</h3>
      <h3>Count : {currentCount}</h3>
      <button onClick={() => setCount((prevState) => prevState + 1)}>Increament</button>
      <button onClick={decreament}>Decreament</button>
      <button onClick={() => setCount(initialCount)}>Reset</button>
      <button onClick={increamentByFive}>Increament by 5</button>
    </div>
  )
}

export default HookCounterTwo
