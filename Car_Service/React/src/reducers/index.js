import { combineReducers } from 'redux'

import reservation from './reservationDate'
import app from './app'
import workers from './workers'
import worker from './worker'

const rootReducer = combineReducers({
    reservation,
    app,
    workers,
    worker
})

export default rootReducer