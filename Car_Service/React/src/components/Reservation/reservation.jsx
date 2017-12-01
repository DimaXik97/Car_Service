import React from 'react';
import ReCAPTCHA from "react-google-recaptcha";
import DatePicker from 'react-datepicker';
import moment from 'moment';

import SelectWorker from "./../../components/SelectWorker/index.jsx"

class Form extends React.Component{
    constructor(props) {
        super(props);
        this.captcha="";
        this.onChange=this.onChange.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }
    componentWillMount(){
        this.props.getWorkers();
    }
    handleChange(e){
        e.preventDefault();
        let captcha = this.captcha;
        let files=[];
        let purpose= this.refs.purpose.value;
        let breakdownDetails= this.refs.breakdownDetails.value;
        let desiredDiagnosis= this.refs.desiredDiagnosis.value;
        let worker= this.props.worker;
        let dateStart = (this.props.startTime).toISOString() ;
        let dateEnd = (this.props.endTime).toISOString();
        for (var x = 0; x < this.refs.files.files.length; x++) {
            files.push(this.refs.files.files[x]);
        }
        this.props.addReservation(worker,purpose,desiredDiagnosis,breakdownDetails,files, captcha, dateStart, dateEnd)
        this.refs.form.reset();
    }
    onChange(value) {
        this.captcha=value;
    }
    render(){
        console.log("sasd",this.props);
        return (
            <form className="default-form" ref="form">
                <input type="text" placeholder="Цель визита" required ref="purpose"/>
                <textarea placeholder="Детали поломки" rows={2} maxLength={64} ref="breakdownDetails"></textarea>
                <input type="text" placeholder="Желаемая диагностика " required ref="desiredDiagnosis"/>
                <SelectWorker
                    changeSelectedWorker={this.props.changeWorker}
                    workers={this.props.workers}
                />
                <DatePicker
                    selected={this.props.startTime}
                    onChange={this.props.setStartTime}
                    shouldCloseOnSelect={false}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={60}
                    dateFormat="LLL"
                    includeDates = {this.props.workDate}
                    excludeTimes={this.props.workTime}
                />
                <DatePicker
                    selected={this.props.endTime}
                    onChange={this.props.setEndTime}
                    shouldCloseOnSelect={false}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={60}
                    dateFormat="LLL"
                    includeDates = {this.props.possibleEndDate}
                    excludeTimes={this.props.possibleEndTime}
                />
                <input type="file" ref="files" name="photo" accept="image/*" required multiple title="Загрузите одну или несколько фотографий"/>
                <ReCAPTCHA
                    ref="recaptcha"
                    sitekey={this.props.captchaKey}
                    onChange={this.onChange}
                />
                <input type="submit" className="default-btm" value="Отправить" required onClick={this.handleChange}/>
            </form>
        );
    }
};

export default Form;