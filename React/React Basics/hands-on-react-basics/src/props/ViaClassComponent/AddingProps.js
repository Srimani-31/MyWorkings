import {Component} from './react'

class AddingProps extends Component {
    render(props)
    {
        return (
            <h1>Hello {this.props.friendName}</h1>
        )
    }
}

export default AddingProps;