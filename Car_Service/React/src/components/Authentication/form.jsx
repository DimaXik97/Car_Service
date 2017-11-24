import React from 'react';

class Form extends React.Component{
    constructor(props) {
        super(props);
        this.handle = this.handle.bind(this);
    }
    handle(event){
        if(this.refs.Form.checkValidity())
        {
            event.preventDefault();
            let email= this.refs.Email.value;
            let password = this.refs.Password.value;
            this.props.login(email, password);
        }
            
    }
    render(){
        return (
            <form ref="Form">
                <input type="email" ref="Email" placeholder="Введите Email" required/>
                <input type="password" ref="Password" placeholder="Введите пароль" required/>
                <input type="submit" className="default-btm" value="Войти" required onClick={this.handle}/>
            </form>
        );
    }
};

export default Form;