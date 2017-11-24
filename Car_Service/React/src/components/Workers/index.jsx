import React from 'react';
import AddWorker from './addWorker.jsx';
import ListWorkers from './listWorker.jsx';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';

class Main extends React.Component{
    constructor(props) {
        super(props);
        this.props.initWorkers();
    }
    render(){
        console.log(this.props)
        return (<div>
            <div className="content">
                <Header text="Рабочие"/>
                <AddWorker 
                    addWorker={this.props.addWorker}
                />
                <ListWorkers
                    deleteBtm={false}
                    workers={this.props.workers}
                    url={this.props.url}
                />
            </div>
            <Footer/>
        </div>);
    }
};
export default Main;