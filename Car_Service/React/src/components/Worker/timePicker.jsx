import React from 'react';

import DatePicker from 'react-datepicker';
import TimePicker from 'rc-time-picker';
import moment from 'moment';

import Header from './../Header/index.jsx';
import Footer from './../Footer/index.jsx';


import 'react-datepicker/dist/react-datepicker.css';

class Picker extends React.Component{
    render(){
        return (
            <TimePicker
                onChange={this.props.onChange}
                defaultValue={moment("00.00", this.props.formatTime)}
                disabledHours={this.props.disabledHours}
                showSecond={false}
                minuteStep={60}
                placeholder="Выберете время"
            />
            );
    }
};
Picker.defaultProps = {
    disabledHours: ()=>{return []}
};
export default Picker;