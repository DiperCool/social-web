import React, { useState,useEffect, useContext } from "react";
import { Posts } from "../PostComponents/Posts"
import {getInfoUser} from "../../Api/ProfiIeApi/getInfoUser"
import {SubscribeButton} from "../SubscribesComponents/SubscribeButton";
import { InfoUser } from "./MyProfileComponents/InfoUser";
import {isSubscribe} from "../../Api/SubscribeApi/isSubscribe";
import {UserContext} from "../UserComponent/UserContext";
import { VerticalLoading } from "../VerticalLoading";
import { ViewSubscribes } from "../SubscribesComponents/ViewSubscribes";
import { getSubscribers } from "../../Api/SubscribeApi/getSubscribers";
import { getSubscribed } from "../../Api/SubscribeApi/getSubscribed";
export const ProfileUser=(props)=>{

    let [info, setInfo]=useState({ava:{
        urlImg:""
    }});
    let [subs, setSubs]=useState({
        subscibes:0,
        subscribed:0
    })

    let [isSubs, setIsSubs]= useState(false);
    let {Auth}=useContext(UserContext)
    let [load, setLoad]=useState(true);

    useEffect(()=>{
        const getInfo=async()=>{
            setLoad(true);
            let res= await getInfoUser(props.match.params.login)
            setSubs({
                subscibes:res.data.countSubscribers,
                subscribed:res.data.countSubscribed
            })
            setInfo(res.data);
            if(Auth.isAuth){
                let res2= await isSubscribe(props.match.params.login, Auth.login);
                setIsSubs(res2);
            }
            setLoad(false);
        }
        getInfo();
    },[props.match.params.login])


    let profile=()=>{
        return(
            <div>
                <InfoUser login={props.match.params.login} ava={info.ava.urlImg} about={info.infoUserAboutMe}/>
                    {Auth.isAuth?
                    <SubscribeButton 
                    login={props.match.params.login} 
                    isSubs={isSubs}/>
                    :
                    null}
                <ViewSubscribes login={props.match.params.login} func={getSubscribers} text={"Посмотреть подписчиков "+subs.subscibes}/>
                <ViewSubscribes login={props.match.params.login} func={getSubscribed} text={"Посмотреть подписки "+subs.subscribed}/>
            </div>
        )
    }

    return(
        <div>
            <div>
                {load?<VerticalLoading/>: profile()}
            </div>
            <div>
                <Posts 
                    login={props.match.params.login} 
                    ava={info.ava.urlImg} 
                    settings={false}
                    typeDownPanel={"withComment"}
                    typeUpPanel={"noSettings"}/>
           </div>
        </div>
    )
}