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
import { Menu } from './components/MenuComponents/Menu';
import {ViewMenuWithComponent} from "./components/MenuComponents/ViewMenuWithComponent"
export const App=()=>{

  const funcViewMenu=(comp)=>{
    return (props)=> <ViewMenuWithComponent comp={comp(props)} />
  }

  return(
    <User>
      <div>
      <BrowserRouter>
        <Switch>
          <Route exact path="/myprofile/change/:id" component={funcViewMenu(ChangePost)} />
          <Route path="/login" component={funcViewMenu(Login)}/>
          <Route exact path="/myprofile" component={funcViewMenu(MyProfile)}/>
          <Route path="/NewPost" component={funcViewMenu(NewPost)}/>
          <Route path="/register" component={funcViewMenu(Register)}/>
          <Route path="/profile" component={funcViewMenu(Profile)} />
          <Route path="/Slider" component={Slider}/>
          <Route path="/profileUser/:login" component={funcViewMenu(ProfileUser)}/>
        </Switch>
      </BrowserRouter>
      </div>
    </User>
  )
}