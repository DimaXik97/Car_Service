import { combineReducers } from 'redux'

import bookingDate from './reservationDate'
import app from './app'
import workers from './workers'
import worker from './worker'

const rootReducer = combineReducers({
    bookingDate,
    app,
    workers,
    worker
})

export default rootReducer