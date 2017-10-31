import React from 'react';
import {Link} from 'react-router-dom';
import {
    BrowserRouter as Router,
    Route,
    Redirect,
    Switch
  } from 'react-router-dom';
import history from "./history.js";

import Start from './../Start/index.jsx';

import Registration from './../Registration/index.jsx';
import Main from './../Reservation/index.jsx'
import Authentication from './../Authentication/index.jsx';
import Workers from './../../containers/workers.js';
import Worker from './../Worker/index.jsx';



class App extends React.Component{
    render(){
        return (
            <Router>
                <Switch>
                    <Route exact path="/" render={() => (this.props.user?<Main/>:<Start/>)}/>
                    <Route path="/login" render={() => (this.props.user?(<Redirect to="/"/>):<Authentication/>)}/>
                    <Route path="/registration" render={() => (this.props.user?(<Redirect to="/"/>):<Registration/>)}/>
                    <Route path="/admin" render={() => (this.props.user.role=="admin"?(<Switch>
                        <Route exact path="/admin" render={() => (<Redirect to="/admin/worker"/>)}/>
                        <Route path="/admin/worker/:id" render={() => <Worker/>}/>
                        <Route path="/admin/worker" render={() => <Workers/>}/>
                    </Switch>):(<Redirect to="/login"/>))}/>
                </Switch>
            </Router>
        );
    }
};

export default App;