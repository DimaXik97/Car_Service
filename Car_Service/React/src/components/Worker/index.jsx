import React from 'react';

import Header from './../Header/index.jsx';
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
        console.log(this.props);
        return (<div>
            <div className="content">
                <Header text="Добавить рабочее время"/>
                <AddWorkDate
                    addWorkTime={this.props.addWorkTime}
                    reset={this.props.reset}
                    setStartTime= {this.props.setStartTime}
                    setEndTime = {this.props.setEndTime}
                    worker={this.props.worker}
                    startTime={this.props.startTime}
                    endTime={this.props.endTime}
                />
            </div>
            <Footer/>
        </div>);
    }
};
export default Worker;