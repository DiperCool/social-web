import React, { useState, useContext,useEffect } from "react";
import {Button} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import {UserContext} from "../UserComponent/UserContext";
import { Posts } from "./MyProfileComponents/Posts";
import {getInfoUser} from "../../Api/ProfileApi/getInfoUser";
import { InfoUser } from "./MyProfileComponents/InfoUser";
export const ProfileUser=(props)=>{

    let [red, setRed]=useState(false);
    let [info, setInfo]=useState({ava:""});

    useEffect(()=>{
        const getInfo=async()=>{
            let res= await getInfoUser(props.match.params.login)
            setInfo(res.data);
        }
        getInfo();
    },[])
    return(
        <div>
            <div>
                <InfoUser login={props.match.params.login} ava={info.ava.urlImg} about={info.infoUserAboutMe}/>
            </div>
            <div>
                <Posts login={props.match.params.login} ava={info.ava.urlImg} settings={false}/>
           </div>
        </div>
    )
}