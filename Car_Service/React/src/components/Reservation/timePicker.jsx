import React from 'react';
import moment from 'moment';

import TimePicker from 'rc-time-picker';
import 'rc-time-picker/assets/index.css';

class Picker extends React.Component{
    constructor(props) {
        super(props);
        this.disabledHours=this.disabledHours.bind(this);
        this.time=this.props.time?moment(this.props.time,this.props.format):null;
        this.onChange=this.onChange.bind(this);
    }
    disabledHours(){
        let arrFreeHour= this.props.freeTimes.map(element=>{
            return moment(element,this.props.format).hour();
        });
        const arr = [];
        for (let value = 0; value < 24; value++) {
            if (arrFreeHour.indexOf(value) < 0) {
            arr.push(value);
            }
        }
        return arr;
    }
    onChange(value) {
        value.minute(0).second(0);
        this.props.selectTime(value.format(this.props.format));
    }
    render(){
        return <TimePicker
            showSecond={false}
            onChange={this.onChange}
            disabledHours={this.disabledHours}
            minuteStep={60}
            placeholder="Выберете время"
        />
    }
};

export default Picker