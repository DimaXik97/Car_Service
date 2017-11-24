import React from 'react';
import ReCAPTCHA from "react-google-recaptcha";

import SelectWorker from "./../../components/SelectWorker/index.jsx"
import DatePicker from "./datePicker.jsx"
import TimePicker from "./timePicker.jsx"
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
        for (var x = 0; x < this.refs.files.files.length; x++) {
            files.push(this.refs.files.files[x]);
        }
        this.props.addReservation(worker,purpose,desiredDiagnosis,breakdownDetails,files, captcha, "secretCaptchaKey")
        /*e.preventDefault();
        let t={
            date: this.props.date,
            time: this.props.time,
            captcha: this.captcha,
            files: this.refs.files.files
        };
        let data = new FormData();
        
        data.append("date",this.props.date);
        data.append("timeStart",this.props.time);
        data.append("captcha",this.captcha);
        console.log(data);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'http://localhost:29975/api/reservation', false);

        // 3. Отсылаем запрос
        xhr.send(data);*/
    }
    onChange(value) {
        this.captcha=value;
    }
    render(){
        console.log("sasd",this.props);
        return (
            <form className="default-form">
                <input type="text" placeholder="Цель визита" required ref="purpose"/>
                <textarea placeholder="Детали поломки" rows={2} maxLength={64} ref="breakdownDetails"></textarea>
                <input type="text" placeholder="Желаемая диагностика " required ref="desiredDiagnosis"/>
                <SelectWorker
                    changeSelectedWorker={this.props.changeWorker}
                    workers={this.props.workers}
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
/*<DatePicker
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
                    selected={this.props.startTime}
                    onChange={this.props.setStartTime}
                    shouldCloseOnSelect={false}
                    showTimeSelect
                    timeFormat="HH:mm"
                    timeIntervals={60}
                    dateFormat="LLL"
                />*/