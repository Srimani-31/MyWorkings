import React from 'react'
import { useState } from 'react'
function HookCounterThree() {
  const [name, setName] = useState({ firstName: '', lastName: '' })
  // const handleChange =(e)=>{
  //     setName(prevState=> ({...prevState,[e.target.id]: e.target.value}))
  //     }
  return (
    <>
      <form>
        <input
          type="text"
          value={name.firstName}
          onChange={e => setName({ ...name, firstName: e.target.value })}
        />
        <input
          type="text"
          value={name.lastName}
          onChange={e => setName({ ...name, lastName: e.target.value })}
        />
      </form>
      <h3>Your firstName is {name.firstName}</h3>
      <h3>Your lastName is {name.lastName}</h3>
      <h3>{JSON.stringify(name)}</h3>
    </>
  )
}

export default HookCounterThree


//after changing focus to last name from first name the value in the state vanishes
//becoz the setState doesn't merges the various property 
//we have to do it manually
