import React from 'react'

class ClickEventClassComponent extends React.Component {
    btnClicked(){
        console.log("Button clicked")
        document.getElementById('demo').innerHTML = "Button click fired!!!"
    }
    render(){
        return (
            <>
            <button onClick={this.btnClicked}>Click Class Component</button>
            <p id="demo"></p>
            </>
        )
    }
}

export default ClickEventClassComponent;