const initState={
    workers:[
        {
            id: 1,
            name: "Nikolay"
        },
        {
            id: 2,
            name: "Viktor"
        },
        {
            id: 3,
            name: "Maksim"
        },
        {
            id: 4,
            name: "Vladislav"
        },
        {
            id: 5,
            name: "Nikita"
        },
        {
            id: 6,
            name: "Sergey"
        }
    ]
};
const workers = (state = initState, action) => {
    switch (action.type) {
    default:
      return state
    }
}

export default workers;