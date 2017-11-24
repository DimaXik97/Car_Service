import React from 'react';
import {
    Link
  } from 'react-router-dom';

class Content extends React.Component{
    render(){
        return (<div>
            <p>Чтобы продолжить использовать сайт авторизуйтесь или зарегистрируйтесь</p>
            <ul>
                <li><Link to="/login">Войти</Link></li>
                <li><Link to="/registration">Регистрация</Link></li>
            </ul>
        </div>);
    }
};
export default Content;