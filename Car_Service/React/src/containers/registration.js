import { connect } from 'react-redux'

import Registration from '../components/Registration/index.jsx';
import {registrationUser} from '../actions';

const mapStateToProps = state => ({
})

const mapDispatchToProps = dispatch => ({
    registration:(name, email, pass)=>{
        dispatch(registrationUser(name, email, pass))
    }
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Registration)