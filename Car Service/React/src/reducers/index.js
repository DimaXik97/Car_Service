import { combineReducers } from 'redux'

import bookingDate from './bookingDate'
import app from './app'

const rootReducer = combineReducers({
    bookingDate,
    app
})

export default rootReducer