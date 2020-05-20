import React, { useState, useContext,useEffect } from "react";
import {Redirect} from "react-router-dom";
import {UserContext} from "../UserComponent/UserContext";
import {Posts} from "../PostComponents/Posts"
import {getInfoUser} from "../../Api/ProfiIeApi/getInfoUser";
import { InfoUser } from "./MyProfileComponents/InfoUser";
import { Button } from "@material-ui/core";
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
                <Button variant="contained" color="primary" onClick={RedirectClick}>Новый пост</Button>
            </div>
            <div>
                <Posts login={Auth.login} settings={true}/>
           </div>
        </div>
    )
}


    