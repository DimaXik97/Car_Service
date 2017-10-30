import React from 'react';

import Start from './../Start/index.jsx';

import Registration from './../Registration/index.jsx';
import Main from './../Reservation/index.jsx'
import Authentication from './../Authentication/index.jsx';
import Workers from './../../containers/workers.js';
import Worker from './../Worker/index.jsx';



class App extends React.Component{
    render(){
        return (
            <Worker/>
        );
    }
};

export default App;