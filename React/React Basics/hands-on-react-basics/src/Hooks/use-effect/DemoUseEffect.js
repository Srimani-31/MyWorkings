//setting the document title
import React from 'react';
import { useEffect, useState } from 'react';

function DemoUseEffect() {
    const [clickCount, SetClickCount] = useState(0);

    useEffect(() => {
        console.log('useEffect');
        document.title =`you clicked ${clickCount} times`
    })

    return (
        <div>
            <h3>Component life cycle in functional component</h3>
            <button onClick={() => SetClickCount(prevState => prevState + 1)}>{clickCount} Clicks so far</button>
        </div>
    )
}

export default DemoUseEffect


//create a functional component
//import useEffect()
//use useEffect function
//write a function inside it for conditional rendering
//ComponentMount, ComponentUpdate, ComponentUnMount

// ```jsx
// import React, { useEffect } from 'react';

// function MyComponent() {
//   useEffect(() => {
//     // Code here runs after the component is mounted
//     return () => {
//       // Code here runs when the component is unmounted
//     };
//   }, []); // Empty dependency array means this effect only runs once on mount

//   return (
//     // JSX for rendering the component
//   );
// }
// ```