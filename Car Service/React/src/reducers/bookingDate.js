const initState={
    workers: [
        {
            id:1,
            name:"Nikolay",
            freeTime:[
                {
                    date: "27.10.2017",
                    time:["8.00","9.00","10.00"]
                },
                {
                    date: "28.10.2017",
                    time:["8.00","10.00", "12.00","17.00"]
                },
                {
                    date: "30.10.2017",
                    time:["8.00","9.00","10.00", "12.00","17.00"]
                },
                {
                    date: "31.10.2017",
                    time:["8.00","9.00", "12.00","17.00"]
                }
            ]
        },
        {
            id:2,
            name:"Sergey",
            freeTime:[
                {
                    date: "26.10.2017",
                    time:["17.00"]
                },
                {
                    date: "27.10.2017",
                    time:["8.00", "12.00","17.00"]
                },
                {
                    date: "28.10.2017",
                    time:["9.00","10.00", "12.00","17.00"]
                },
                {
                    date: "31.10.2017",
                    time:["8.00","12.00","17.00"]
                },
            ]
        },
        {
            id:3,
            name:"Nikita",
            freeTime:[
                {
                    date: "31.10.2017",
                    time:["8.00"]
                },
                {
                    date: "01.11.2017",
                    time:["8.00","9.00","17.00"]
                },
                {
                    date: "08.11.2017",
                    time:["8.00","9.00","10.00", "12.00","17.00"]
                }
            ]
        },
    ],
    worker: undefined,
    date:undefined,
    time: undefined
};
const worker = (state = initState, action) => {
    switch (action.type) {
        case "SELECT_WORKER": {
            return Object.assign({}, state, {
                worker: action.selectWorker});
        }
        case "SELECT_DATE": {
            return Object.assign({}, state, {
                date: action.selectDate});
        }
        case "SELECT_TIME": {
            return Object.assign({}, state, {
                time: action.selectTime});
        }
    default:
      return state
    }
}

export default worker;