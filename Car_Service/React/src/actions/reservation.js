export const selectWorker= (worker)=>({
    type: 'SELECT_WORKER',
    selectWorker: worker
})
export const addReservation=(worker,purpose,desiredDiagnosis,breakdownDetails,files, captcha, secretCaptchaKey)=>({
    type: 'ADD_RESERVATION',
    worker,
    purpose,
    desiredDiagnosis,
    breakdownDetails,
    files, 
    captcha, 
    secretCaptchaKey
})