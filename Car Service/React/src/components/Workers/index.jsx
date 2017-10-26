import React from 'react';
import AddWorker from './addWorker.jsx';
import ListWorkers from './../../containers/workers.js';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Main extends React.Component{
    render(){
        return (<div>
            <Header text="Рабочие"/>
            <AddWorker/>
            <ListWorkers deleteBtm={false}/>
            <Footer/>
        </div>);
    }
};
export default Main;