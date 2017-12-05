import { put, takeEvery,call } from 'redux-saga/effects';
import { setWorker} from './../actions';
import { postJSON, getJSON } from './../helpers';
import history from "./../components/App/history"
const urlWorker ="http://localhost:29975/api/worker";

export function* addTime(action){
    let data={
        startTime: action.startTime,
        endTime: action.endTime
    }
    let result = yield call (postJSON, `${urlWorker}/${action.id}/workTime`, data);
    if(result.succsses){
        alert("OK");
    }
}
export function* getWorker(action){
    let result = yield call (getJSON, `${urlWorker}/${action.id}`);
    if(result.succsses){
        yield put(setWorker(result.data.Id, `${result.data.Name} ${result.data.SurName}`, result.data.Telephone, result.data.Email));
    }
}
export default function* rootSaga() {
    yield takeEvery('ADD_WORK_TIME', addTime),
    yield takeEvery('GET_WORKER', getWorker)
}