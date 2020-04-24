import React, { useState, useContext,useEffect } from "react";
import {Button} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import {UserContext} from "../UserComponent/UserContext";
import { Posts } from "./MyProfileComponents/Posts";
import {getInfoUser} from "../../Api/ProfileApi/getInfoUser";
import { InfoUser } from "./MyProfileComponents/InfoUser";
export const MyProfile=()=>{

    let [red, setRed]=useState(false);
    let {Auth}= useContext(UserContext);
    let [info, setInfo]=useState({ava:""});
    const RedirectClick=()=>{
        setRed(true);
    }

    useEffect(()=>{
        const getInfo=async()=>{
            let res= await getInfoUser(Auth.login)
            setInfo(res.data);
        }
        getInfo();
    },[])

    if(red) return <Redirect to="NewPost"/>
    return(
        <div>
            <div>
                <InfoUser login={Auth.login} ava={info.ava.urlImg} about={info.infoUserAboutMe}/>
            </div>
            <div>
                <Posts login={Auth.login} ava={info.ava.urlImg} settings={true}/>
           </div>
        </div>
    )
}


    