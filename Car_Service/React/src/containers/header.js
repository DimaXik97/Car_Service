import { connect } from 'react-redux'

import Header from '../components/Header/index.jsx';
import {logoutUser} from '../actions';

const mapStateToProps = state => ({
    isLogin: state.app.user.token!=null
})

const mapDispatchToProps = dispatch => ({
    logoutUser:()=>{
        dispatch(logoutUser())
    }
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Header)