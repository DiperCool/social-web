import React from 'react';
import { Route, Redirect } from 'react-router-dom';
import {ViewMenuWithComponent} from "./components/MenuComponents/ViewMenuWithComponent";

export const PublicRoute = ({component: Component, ...rest}) => {
    return (
        <Route {...rest} render={props => (
            <ViewMenuWithComponent Comp={<Component {...props}/>} />
        )} />
    );
};
