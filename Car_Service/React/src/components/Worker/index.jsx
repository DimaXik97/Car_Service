import React from 'react';

import Header from './../../containers/header';
import Footer from './../Footer/index.jsx';
import AddWorkDate from './addWorkDate.jsx'

class Worker extends React.Component{
    constructor(props){
        super(props);
    }
    componentWillMount(){
        this.props.getWorker(this.props.match.params.id)
    }
    render(){
        return (<div>
                <Header/>
                <AddWorkDate 
                    addWorkTime={this.props.addWorkTime}
                    reset={this.props.reset}
                    setStartTime= {this.props.setStartTime}
                    setEndTime = {this.props.setEndTime}
                    worker={this.props.worker}
                    startTime={this.props.startTime}
                    endTime={this.props.endTime}
                />
            <Footer/>
        </div>);
    }
};
export default Worker;