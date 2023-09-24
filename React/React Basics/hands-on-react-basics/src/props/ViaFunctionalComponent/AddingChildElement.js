
const AddingChildElement = (props) => {
  console.log(props)
  return (
    <>
      <h1>This is {props.friendName}</h1>
      {props.children}
    </>
  )
}

export default AddingChildElement;