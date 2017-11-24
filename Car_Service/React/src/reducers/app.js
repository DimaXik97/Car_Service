const initState={
    captchaKey: "6LfTizUUAAAAAPrKN5EuUDOKNgIBk1ec0aYi3jyD",
    formatDate: "DD.MM.YYYY",
    formatTime: "HH.mm",
    workerURL: "/admin/worker",
    user: {token :window.localStorage.getItem("app_token"),
        role: window.localStorage.getItem("app_role") }
};
const app = (state = initState, action) => {
    switch (action.type) {
        case "INIT_USER":{
            return Object.assign({}, state, {
                user: {
                    token: action.token,
                    role: action.role
                }});
        }
        case "DESTROY_USER":{
            return Object.assign({}, state, {
                user: {
                    token: null,
                    role: null
                }});
        }
    default:
      return state
    }
}

export default app;