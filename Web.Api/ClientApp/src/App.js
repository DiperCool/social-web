import React from 'react';
import { BrowserRouter,Route, Switch, Redirect } from 'react-router-dom';
import {Login} from "./components/AuthComponents/Login"
import { Register } from './components/AuthComponents/Register';
import { Profile } from './components/ProfileComponents/Profile';
import {User} from "./components/UserComponent/User"
import {MyProfile} from "./components/ProfileComponents/MyProfile"
import {NewPost} from "./components/ProfileComponents/MyProfileComponents/NewPost"
import {ChangePost} from "./components/PostComponents/ChangePostComponents/ChangePost"
import { ProfileUser } from './components/ProfileComponents/ProfileUser';
import {ViewMenuWithComponent} from "./components/MenuComponents/ViewMenuWithComponent"
import { PostViewAll } from './components/PostViewAllComponents/PostViewAll';
import { PrivateRoute } from './PrivateRoute';
import {PublicRoute} from "./PublicRoute";
export const App=()=>{

  const funcViewMenu=(comp)=>{
    return (props)=> <ViewMenuWithComponent comp={comp(props)} />
  }

  return(
    <User>
      <BrowserRouter>
        <Switch>
          <PrivateRoute exact path="/post/change/:id" component={ChangePost} />
          <PrivateRoute exact path="/myprofile" component={MyProfile}/>
          <PrivateRoute exact path="/NewPost" component={NewPost}/>
          <PrivateRoute exact path="/profile" component={Profile} />


          <PublicRoute exact path="/login" component={Login}/>
          <PublicRoute exact path="/register" component={Register}/>
          <PublicRoute exact path="/profileUser/:login" component={ProfileUser}/>
          <PublicRoute exact path="/post/:login/:id" component={PostViewAll}/>
          <Redirect to={"/myprofile"}/>
        </Switch>
      </BrowserRouter>
    </User>
  )
}

