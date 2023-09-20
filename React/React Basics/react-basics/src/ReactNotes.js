import React from 'react'

function ReactNotes() {
  return (
    <>
      <div>
        <h3>how react works on state management?</h3>
        <p>When the states changes it re-renders the entire component tree for us</p>
        <p>Re-renders everytime we add a todo, delete todo, update a todo</p>
      </div>
      <div>
        <h3>useState React Hook</h3>
        <p>returns an array we can destructure that and then said it to useState</p>
      </div>
      <div>
        <h3>props</h3>
        <p>every component has props we can pass them like attributes in app.component </p>
      </div>
    </>

  )
}

export default ReactNotes;
