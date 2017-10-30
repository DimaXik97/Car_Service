import React from 'react';

import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';
import AddWorkDate from './../../containers/worker.js'

class Main extends React.Component{
    render(){
        return (<div>
            <div className="content">
                <Header text="Добавить рабочее время"/>
                <AddWorkDate/>
            </div>
            <Footer/>
        </div>);
    }
};
export default Main;