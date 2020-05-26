import React, { useState,useEffect, useContext } from "react";
import { Posts } from "../PostComponents/Posts"
import {getInfoUser} from "../../Api/ProfiIeApi/getInfoUser"
import {SubscribeButton} from "../SubscribesComponents/SubscribeButton";
import { InfoUser } from "./MyProfileComponents/InfoUser";
import {isSubscribe} from "../../Api/SubscribeApi/isSubscribe";
import {UserContext} from "../UserComponent/UserContext";
import { VerticalLoading } from "../VerticalLoading";
export const ProfileUser=(props)=>{

    let [info, setInfo]=useState({ava:{
        urlImg:""
    }});


    let [isSubs, setIsSubs]= useState(false);
    let {Auth}=useContext(UserContext)
    let [load, setLoad]=useState(true);

    useEffect(()=>{
        const getInfo=async()=>{
            setLoad(true);
            let res= await getInfoUser(props.match.params.login)
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
                    typeDownPanel={"noComments"}
                    typeUpPanel={"noSettings"}/>
           </div>
        </div>
    )
}