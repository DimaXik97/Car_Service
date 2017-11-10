import { connect } from 'react-redux'

import Worker from '../components/Worker/addWorkDate.jsx';
import {setStartTime,setWorkDate,setEndTime} from '../actions';

const mapStateToProps = state => ({
    worker: state.worker.worker,
    format: state.app.formatDate,
    date: state.worker.date,
    workingDates: state.worker.workingDates,
    formatTime: state.app.formatTime,
    startTime: state.worker.startTime,
    endTime: state.worker.endTime
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
)(Worker)