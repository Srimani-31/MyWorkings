import React from 'react'
import Student from './ClassComponentStudent'
import Student1 from './FunctionalComponentStudent'
export default function DestructuringProps() {
  return (
    <>
  <Student name="Srimanikandan" age="10"/>
  <Student1 name="Nirmal Raj" age="20" />
    </>
  )
}
