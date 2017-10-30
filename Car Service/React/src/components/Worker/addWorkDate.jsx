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
        this.setStartTime=this.setStartTime.bind(this);
        this.setEndTime=this.setEndTime.bind(this);
        this.setDate=this.setDate.bind(this);
        this.disabledHours=this.disabledHours.bind(this);
        this.addWorkTime=this.addWorkTime.bind(this);
    }
    componentWillMount(){
        this.props.reset();
    }

    setStartTime(value) {
        this.props.setStartTime(value.format(this.props.formatTime))
    }
    setEndTime(value){
        this.props.setEndTime(value.format(this.props.formatTime))
    }
    setDate(value){
        this.props.setDate(value.format(this.props.format))
    }

    disabledHours(){
        let hours = [];
        let curentHour=0;
        let loopVar = Boolean(this.props.startTime);
        while(loopVar)
        {
            hours.push(curentHour);
            curentHour++;
            loopVar=!(curentHour==moment(this.props.startTime,this.props.formatTime).hour()+1);
        }
        return hours;
    }
    addWorkTime(event){
        event.preventDefault();
        let id=this.props.worker.id;
        let date=this.props.date;
        let startTime = this.props.startTime;
        let endTime= this.props.endTime;
        console.log(id, date, startTime, endTime);
    }

    render(){
        return (<div>
            <p>{this.props.worker.name}</p>
            <form>
                <DatePicker
                    minDate={moment()}
                    maxDate={moment().add(1, "months")}
                    selected={this.props.date?moment(this.props.date, this.props.format):null}
                    onChange={this.setDate}
                    dateFormat={this.props.format}
                    locale="ru-ru"
                    placeholderText="Выберете дату"
                    excludeDates={this.props.workingDates.map((element)=>{
                        return moment(element, this.props.format);
                    })}
                />
                <TimePicker
                    onChange={this.setStartTime}
                    formatTime={this.props.formatTime}
                />
                <TimePicker
                    onChange={this.setEndTime}
                    disabledHours={this.disabledHours}
                    formatTime={this.props.formatTime}
                />
                <input type="submit" value="Добавить время" onClick={this.addWorkTime}/>
            </form>
        </div>);
    }
};
export default Main;