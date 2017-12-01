import React from 'react';

import DatePicker from 'react-datepicker';
import moment from 'moment';

import TimePicker from './timePicker.jsx';
import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';


import 'react-datepicker/dist/react-datepicker.css';

class Main extends React.Component{
    constructor(props) {
        super(props);
        this.addWorkTime=this.addWorkTime.bind(this);
    }
    componentWillMount(){
        //console.log("dasd",this.props)
        //this.props.getUser(this.props.match.params.id);
    }
    addWorkTime(event){
        event.preventDefault();
        let id=this.props.worker.id;
        let startTime = this.props.startTime;
        let endTime= this.props.endTime;
        this.props.addWorkTime(id, startTime, endTime);
        this.props.reset();
    }
    render(){
        return (<div>
            <p>{this.props.worker.name}</p>
            <form>
                <DatePicker
                    minDate={moment()}
                    maxDate={moment().add(1,"months")}
                    selected={this.props.startTime}
                    onChange={this.props.setStartTime}
                    shouldCloseOnSelect={false}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={60}
                    dateFormat="LLL"
                />
                <DatePicker
                    minDate={moment()}
                    maxDate={moment().add(1,"months")}
                    selected={this.props.endTime}
                    onChange={this.props.setEndTime}
                    shouldCloseOnSelect={false}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={60}
                    dateFormat="LLL"
                />
                <input type="submit" value="Добавить время" onClick={this.addWorkTime}/>
            </form>
        </div>);
    }
};
export default Main;