import { put, takeEvery,call } from 'redux-saga/effects';
import { addReservation} from './../actions';
import { postJSON, getJSON } from './../helpers';

const urlReservation ="http://localhost:29975/api/reservation";

export function* reservation(action){
    console.log(action)
    let data = new FormData();
    for (var x = 0; x < action.files.length; x++) {
        data.append("file", action.files[x]);
    }
    data.append("workerId",action.worker);
    data.append("purpose",action.purpose);
    data.append("breakdownDetails", action.breakdownDetails);
    data.append("desiredDiagnosis", action.desiredDiagnosis);
    let result = yield call (postJSON, urlReservation, data);
    console.log(result);
    if(result.succsses){
        alert("OK");
    }
}

export default function* rootSaga() {
    yield takeEvery('ADD_RESERVATION', reservation)
}