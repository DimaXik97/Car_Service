import { connect } from 'react-redux'

import ReservationForm from '../components/Booking/reservationForm.jsx';
import {selectWorker,selectDate, selectTime} from '../actions';
const getFreeDates=state=>{
    let worker=getWorker(state.workers, state.worker);
    return worker?worker.freeTime.map(element=>{
            return element.date;
        }):[]
} 
const getFreeTimes=state=>{
    let worker=getWorker(state.workers, state.worker);
    return worker&&state.date?worker.freeTime.find(element=>{
        return element.date==state.date
    }).time:[]
}
const getWorker=(workers, idWorker)=>{
    return workers.find((element)=>{
        return element.id==idWorker;
    })
}
const mapStateToProps = state => ({
    workers: state.bookingDate.workers.map((element)=>{
        return {id:element.id, name: element.name};
    }),
    date: state.bookingDate.date,
    worker: state.bookingDate.worker,
    time: state.bookingDate.time,
    freeDates:getFreeDates(state.bookingDate),
    freeTimes: getFreeTimes(state.bookingDate),
    formatDate: state.app.formatDate,
    formatTime: state.app.formatTime,
    captchaKey: state.app.captchaKey
})

const mapDispatchToProps = dispatch => ({
    selectWorker:(idWorker)=>{
        dispatch(selectDate(undefined));
        dispatch(selectTime(undefined));
        dispatch(selectWorker(idWorker));
    },
    selectDate:(date)=>{
        dispatch(selectTime(undefined));
        dispatch(selectDate(date));
    },
    selectTime:(time)=>{
        dispatch(selectTime(time));
    }
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ReservationForm)