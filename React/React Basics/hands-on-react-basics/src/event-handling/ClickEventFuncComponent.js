const ClickEventFuncComponent = () =>{
    const btnClick = () =>{
        console.log('Button clicked');
        document.getElementById('demo').innerHTML = "In JS, we can define a function inside a function"
    }
    return(
        <>
            <button onClick={btnClick}>Click Func Component</button>
            <p id="demo"></p>
        </>
    )
   
}

export default ClickEventFuncComponent;