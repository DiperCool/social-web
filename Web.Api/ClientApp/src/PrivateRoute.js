import React,{useContext} from 'react';
import { Route, Redirect } from 'react-router-dom';
import { UserContext } from './components/UserComponent/UserContext';
import {ViewMenuWithComponent} from "./components/MenuComponents/ViewMenuWithComponent"
export const PrivateRoute = ({component: Component, ...rest}) => {
    let {Auth}= useContext(UserContext);
    return (
        <Route {...rest} render={props => (
            Auth.isAuth ?
                <ViewMenuWithComponent Comp={<Component {...props}/>} />
            : <Redirect to={{
                pathname:"/login",
                state:{from:props.location}
            }} />
        )} />
    );
};