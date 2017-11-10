import React from 'react';

class Form extends React.Component{
    constructor(props) {
        super(props);
        this.validatePassword = this.validatePassword.bind(this);
        this.handle = this.handle.bind(this);
    }
    validatePassword(){
        var pass2=this.refs.Password1.value;
        var pass1=this.refs.Password2.value;
        if(pass1!=pass2)
            this.refs.Password2.setCustomValidity("Passwords Don't Match");
        else
            this.refs.Password2.setCustomValidity('');
    }
    handle(event){
        if(this.refs.Form.checkValidity())
        {
            event.preventDefault();
            let name=this.refs.Name.value;
            let email=this.refs.Email.value;
            let password = this.refs.Password1.value;
            console.log("name",name);
            console.log("email", email);
            console.log("password", password);
        }
            
    }
    render(){
        return (
            <form ref="Form">
                <input type="text" ref="Name" placeholder="Введите ваше имя" required/>
                <input type="email" ref="Email" placeholder="Введите Email" required/>
                <input type="password" ref="Password1" placeholder="Введите пароль" required onChange={this.validatePassword}/>
                <input type="password" ref="Password2" placeholder="Повторите пароль" required onChange={this.validatePassword}/>
                <input type="submit" className="default-btm" value="Зарегестрироваться" required onClick={this.handle}/>
            </form>
        );
    }
};

export default Form;