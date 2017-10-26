import { combineReducers } from 'redux'

import bookingDate from './bookingDate'
import app from './app'
import workers from './workers'
const rootReducer = combineReducers({
    bookingDate,
    app,
    workers
})

export default rootReducer