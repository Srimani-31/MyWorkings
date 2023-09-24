import Message from "./Message"
import Counter from "./Counter";
import RenderPropsIntoStates from "./PropsStatus";
function StatesInClass() {
  return (
    <>
    <Message></Message>
    <Counter/>
    <RenderPropsIntoStates count="5"/>
    </>
  )
}

export default StatesInClass;
