import { connect } from 'react-redux'

import ReservationForm from '../components/Reservation/index.jsx';
import {getWorkers,selectWorker,addReservation} from '../actions';
/*const getFreeDates=state=>{
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
}*/
const mapStateToProps = state => ({
    workers: state.workers.workers,
    captchaKey: state.app.captchaKey,
    worker: state.reservation.worker
    //selectedWorker: state.workers.workers.find(s=>s.id==state.reservation.worker)
    /*
    date: state.bookingDate.date,
    worker: state.bookingDate.worker,
    time: state.bookingDate.time,
    freeDates:getFreeDates(state.bookingDate),
    freeTimes: getFreeTimes(state.bookingDate),
    formatDate: state.app.formatDate,
    formatTime: state.app.formatTime,
    */
})

const mapDispatchToProps = dispatch => ({
    getWorkers:()=>{
        dispatch(getWorkers());
    },
    changeWorker:(id)=>{
        dispatch(selectWorker(id))
    },
    addReservation:(worker,purpose,desiredDiagnosis,breakdownDetails,files, captcha, secretCaptchaKey)=>{
        dispatch(addReservation(worker,purpose,desiredDiagnosis,breakdownDetails,files, captcha, secretCaptchaKey))
    }
    /*selectWorker:(idWorker)=>{
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
    }*/
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(ReservationForm)