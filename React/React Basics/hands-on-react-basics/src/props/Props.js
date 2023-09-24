import Greet from "./ViaFunctionalComponent/Greet";
import AddingProps from "./ViaFunctionalComponent/AddingProps";
import AddingChildElement from "./ViaFunctionalComponent/AddingChildElement";

const Props = () => {
  return (
    <>
      <Greet />
      <AddingProps name="Ronaldo" />
      <AddingChildElement friendName="suresh">
        <p>He is my high school mate</p>
      </AddingChildElement>
    </>
  )
}

export default Props;