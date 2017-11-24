export const loginUser= (email, pass)=>({
    type: 'LOGIN_USER',
    email,
    pass
})
export const initUser= (token, role)=>({
    type: 'INIT_USER',
    token,
    role
})
export const destroyUser= ()=>({
    type: 'DESTROY_USER'
})
export const registrationUser=(userName, email, pass)=>({
    type: 'REGISTRATION_USER',
    email,
    userName,
    pass
})