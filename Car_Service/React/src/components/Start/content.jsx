import React from 'react';

class Content extends React.Component{
    render(){
        return (<div>
            <p>Чтобы продолжить использовать сайт авторизуйтесь или зарегистрируйтесь</p>
            <ul>
                <li><a className="default-btm" href="">Войти</a></li>
                <li><a className="default-btm" href="">Регистрация</a></li>
            </ul>
        </div>);
    }
};
export default Content;