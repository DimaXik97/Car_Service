const initState={
    worker: undefined,
    startTime:undefined,
    endTime: undefined
};
const worker = (state = initState, action) => {
    switch (action.type) {
        case "SELECT_WORKER": {
            return Object.assign({}, state, {
                worker: action.selectWorker});
        }
    default:
      return state
    }
}

export default worker;