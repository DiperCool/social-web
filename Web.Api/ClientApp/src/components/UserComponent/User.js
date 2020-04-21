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


    useEffect(()=>{
        const setGetLogin=async()=>{
            var result=await getLogin()
            console.log(result)
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
        <UserContext.Provider value={{Auth,setLoginAndSetAuth}}>
            {children}
        </UserContext.Provider>
    )
}