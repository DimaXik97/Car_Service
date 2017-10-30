import { connect } from 'react-redux'

import Workers from '../components/Workers/index.jsx';
import {setStartTime,setWorkDate,setEndTime} from '../actions';

const mapStateToProps = state => ({
    workers: state.workers.workers,
    url: state.app.userURL
})

const mapDispatchToProps = dispatch => ({
    reset:()=>{
        dispatch(setStartTime(undefined));
        dispatch(setWorkDate(undefined));
        dispatch(setEndTime(undefined));
    },
    setStartTime:(time)=>{
        dispatch(setStartTime(time));
    },
    setEndTime:(time)=>{
        dispatch(setEndTime(time));
    },
    setDate:(date)=>{
        dispatch(setWorkDate(date));
    }
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Workers)