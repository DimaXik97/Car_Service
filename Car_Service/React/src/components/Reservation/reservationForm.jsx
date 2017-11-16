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
    handleChange(e){
        e.preventDefault();
        let t={
            date: this.props.date,
            time: this.props.time,
            captcha: this.captcha,
            files: this.refs.files.files
        };
        let data = new FormData();
        for (var x = 0; x < this.refs.files.files.length; x++) {
            data.append("file", this.refs.files.files[x]);
        }
        data.append("date",this.props.date);
        data.append("timeStart",this.props.time);
        data.append("captcha",this.captcha);
        console.log(data);
        var xhr = new XMLHttpRequest();

        // 2. Конфигурируем его: GET-запрос на URL 'phones.json'
        xhr.open('POST', 'http://localhost:29975/api/reservation', false);

        // 3. Отсылаем запрос
        xhr.send(data);
    }
    onChange(value) {
        this.captcha=value;
    }
    render(){
        console.log(this.props.freeDates);
        return (
            <form className="default-form">
                <input type="text" placeholder="Цель визита" required/>
                <textarea placeholder="Детали поломки" rows={2} maxLength={64}></textarea>
                <input type="text" placeholder="Желаемая диагностика " required/>
                <SelectWorker
                    changeSelectedWorker={this.props.selectWorker}
                    selectedWorker={this.props.worker}
                    workers={this.props.workers}
                />
                <DatePicker
                    changeSelectDate={this.props.selectDate}
                    workingDays={this.props.freeDates}
                    date={this.props.date}
                    format= {this.props.formatDate}
                />
                <TimePicker
                    time={this.props.time}
                    freeTimes={this.props.freeTimes}
                    selectTime={this.props.selectTime}
                    format= {this.props.formatTime}
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