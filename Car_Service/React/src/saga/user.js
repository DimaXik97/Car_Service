import { put, takeEvery,call } from 'redux-saga/effects';
import { initUser, destroyUser} from './../actions';
import { postURLEncode,postJSON } from './../helpers';
import history from "./../components/App/history"
const urlToken="http://localhost:29975/api/token";
const urlRegistration ="http://localhost:29975/api/account/regiser";

export function* login(action){
    var details  = {
        username: action.email,
        password: action.pass,
        grant_type: "password"
    }
    var formBody = [];
    for (var property in details) {
      var encodedKey = encodeURIComponent(property);
      var encodedValue = encodeURIComponent(details[property]);
      formBody.push(encodedKey + "=" + encodedValue);
    }
    formBody = formBody.join("&");
    let auth = yield call (postURLEncode, urlToken, formBody);
    if(auth.succsses)
    {
        yield put(initUser(auth.data.access_token, auth.data.role)); 
        window.localStorage.setItem("app_token",auth.data.access_token);
        window.localStorage.setItem("app_role",auth.data.role)
    }
        
}
export function* logOut(){
    yield put(destroyUser()); 
    window.localStorage.clear("app_token");
    window.localStorage.clear("app_role")
        
}
export function* registration(action){
    let data={
        Email: action.email,
        Username: action.userName,
        Password: action.pass
    }
    let registration = yield call (postJSON, urlRegistration, data);
    if(registration.succsses)
        yield call (history.push,"/login");
}
export default function* rootSaga() {
    yield takeEvery('LOGIN_USER', login),
    yield takeEvery('LOGOUT_USER', logOut),
    yield takeEvery('REGISTRATION_USER', registration)
}