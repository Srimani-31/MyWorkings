import React from 'react'

function FunctionalComponentStudent({name,age}) {
  return (
    <div>
      <>
      <h3>DestructuringProps via functional component</h3>
      <h6>{name}'s age is {age}</h6>
      </>
    </div>
  )
}

export default FunctionalComponentStudent;
