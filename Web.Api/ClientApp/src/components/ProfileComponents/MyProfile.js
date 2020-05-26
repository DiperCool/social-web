import React, { useState, useContext,useEffect } from "react";
import {Redirect,Link} from "react-router-dom";
import {UserContext} from "../UserComponent/UserContext";
import {Posts} from "../PostComponents/Posts"
import {getInfoUser} from "../../Api/ProfiIeApi/getInfoUser";
import { InfoUser } from "./MyProfileComponents/InfoUser";
import { Button } from "@material-ui/core";
export const MyProfile=()=>{

    let {Auth}= useContext(UserContext);
    let [info, setInfo]=useState({ava:""});

    useEffect(()=>{
        const getInfo=async()=>{
            let res= await getInfoUser(Auth.login)
            setInfo(res.data);
        }
        getInfo();
    },[])

    return(
        <div>
            <div>
                <InfoUser login={Auth.login} ava={info.ava.urlImg} about={info.infoUserAboutMe}/>

                <Link to={"/NewPost"}>
                    <Button variant="contained" color="primary" >Новый пост</Button>
                </Link>
            </div>
            <div>
                <Posts 
                login={Auth.login} 
                settings={true} 
                typeDownPanel={"withComment"}
                typeUpPanel={"withSettings"}/>
           </div>
        </div>
    )
}


    