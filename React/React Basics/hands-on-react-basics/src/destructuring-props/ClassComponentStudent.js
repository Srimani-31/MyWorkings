import React from 'react'
class ClassComponentStudent extends React.Component {
    render(){
        const {name, age} = this.props
        return (
            <>
                <h3>DestructuringProps via class component</h3>
                <h6>{name}'s age is {age}</h6>
            </>
        )
    }
}

export default ClassComponentStudent;