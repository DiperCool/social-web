import React, { useState, useEffect } from "react";
import {UserContext} from "./UserContext";
import {getLogin} from "../../Api/getLogin";
import {Loading} from "../Loading";
export const User=({children})=>{

    let [Auth, setAuth]= useState({
        login:"",
        isAuth:false,
        isPending:true,
        ava:""
    });


    const setGetLogin=async()=>{
        setAuth({isPending: true})
        var result=await getLogin()
        if(result.status===200){
            setAuth({
                login:result.data.login,
                isAuth:true,
                isPending:false,
                ava:result.data.ava
            })
            return;
        }
        setAuth({
            login:"",
            isAuth:false,
            isPending:false
        });
    }

    useEffect(()=>{
        setGetLogin();
    },[]);


    const setLoginAndSetAuth=(login)=>{
        setAuth({
            login:login,
            isAuth:true,
            isPending:false
        });
    }


    if(Auth.isPending) return <Loading></Loading>;

    return(
        <UserContext.Provider value={{Auth,setLoginAndSetAuth,setGetLogin}}>
            {children}
        </UserContext.Provider>
    )
}