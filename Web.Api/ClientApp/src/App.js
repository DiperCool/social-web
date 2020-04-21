import React from 'react';
import { BrowserRouter,Route, Switch } from 'react-router-dom';
import {Login} from "./components/AuthComponents/Login"
import { Register } from './components/AuthComponents/Register';
import { Profile } from './components/ProfileComponents/Profile';
import {User} from "./components/UserComponent/User"
import {MyProfile} from "./components/ProfileComponents/MyProfile"
import {NewPost} from "./components/ProfileComponents/MyProfileComponents/NewPost"
import {Slider} from "./components/ProfileComponents/MyProfileComponents/Slider"
import {ChangePost} from "./components/ProfileComponents/MyProfileComponents/ChangePost"
import { ProfileUser } from './components/ProfileComponents/ProfileUser';
export const App=()=>{
  return(
    <User>
      <BrowserRouter>
        <Switch>
          <Route exact path="/myprofile/change/:id" component={ChangePost} />
          <Route path="/login" component={Login}/>
          <Route exact path="/myprofile" component={MyProfile}/>
          <Route path="/NewPost" component={NewPost}/>
          <Route path="/register" component={Register}/>
          <Route path="/profile" component={Profile} />
          <Route path="/Slider" component={Slider}/>
          <Route path="/profileUser/:login" component={ProfileUser}/>
        </Switch>
      </BrowserRouter>
    </User>
  )
}