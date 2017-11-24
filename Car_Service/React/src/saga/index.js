import { fork } from 'redux-saga/effects';
import user from './user'
import workers from './workers'
import worker from './worker'
import reservation from './reservation'

export default function* rootSaga() {
  yield fork(user),
  yield fork(workers),
  yield fork(worker),
  yield fork(reservation)
}