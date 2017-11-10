const initState={
    worker: {
        id: 5,
        name: "Nikita"
    },
    workingDates: ["31.10.2017","01.11.2017","02.11.2017","04.11.2017","06.11.2017","08.11.2017"],
    date: undefined,
    startTime: undefined,
    endTime: undefined,
}; 
const workers = (state = initState, action) => {
    switch (action.type) {
        case "SET_START_TIME": {
            return Object.assign({}, state, {
                startTime: action.stertTime});
        }
        case "SET_WORK_DATE": {
            return Object.assign({}, state, {
                date: action.workDate});
        }
        case "SELECT_END_TIME": {
            return Object.assign({}, state, {
                endTime: action.endTime});
        }
    default:
      return state
    }
}

export default workers;