import React from 'react';
import DatePicker from 'react-datepicker';
import moment from 'moment';

import 'react-datepicker/dist/react-datepicker.css';

// CSS Modules, react-datepicker-cssmodules.css
// import 'react-datepicker/dist/react-datepicker-cssmodules.css';

class Picker  extends React.Component {
    constructor (props) {
        super(props);
        this.handleChange=this.handleChange.bind(this);
    }
    handleChange(date) {
        this.props.changeSelectDate(date.format(this.props.format))
    }

    render() {
        return <DatePicker
            selected={this.props.date?moment(this.props.date, this.props.format):null}
            onChange={this.handleChange}
            dateFormat={this.props.format}
            locale="ru-ru"
            placeholderText="Выберете дату"
            includeDates={this.props.workingDays.map(element=>{
                return moment(element, this.props.format);
            })}
        />;
    }
}
export default Picker;