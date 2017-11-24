import React from 'react';

class SelectWorker extends React.Component{
    constructor(props) {
        super(props);
        this.addWorker = this.addWorker.bind(this);
    }
    addWorker(event) {
        if(this.refs.Form.checkValidity())
        {
            event.preventDefault();
            let surName= this.refs.surName.value;
            let firstName= this.refs.firstName.value;
            let email= this.refs.email.value;
            let telephone= this.refs.tel.value;
            this.props.addWorker(surName, firstName, email, telephone);
            this.refs.Form.reset();
        }   
    }
    render(){
        return (<form ref="Form">
            <input type="text" ref="surName"/>
            <input type="text" ref="firstName"/>
            <input type="email" ref="email"/>
            <input type="tel" ref="tel"/>
            <input type="submit" value="Добавить" onClick={this.addWorker}/>
        </form>);
    }
};
export default SelectWorker;