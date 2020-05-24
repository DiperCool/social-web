import React, { useState,useEffect } from "react";
import { Posts } from "../PostComponents/Posts"
import {getInfoUser} from "../../Api/ProfiIeApi/getInfoUser"
import { InfoUser } from "./MyProfileComponents/InfoUser";
export const ProfileUser=(props)=>{

    let [info, setInfo]=useState({ava:{
        urlImg:""
    }});

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