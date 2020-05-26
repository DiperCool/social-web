import React,{useState,useEffect} from "react";
import { Button } from "@material-ui/core";
import {subscribeToUser} from "../../Api/SubscribeApi/subscribeToUser";
import { unSubcribe } from "../../Api/SubscribeApi/unSubcribe";
export const SubscribeButton=({login, isSubs})=>{

    let [IsSubs, setIsSubs]=useState(isSubs);
    const handleClick=async()=>{
        if(IsSubs){
            unSubcribe(login);
            setIsSubs(false);
            return;
        }
        subscribeToUser(login);
        setIsSubs(true);
    }

    useEffect(()=>{
        setIsSubs(isSubs);
    },[isSubs])

    return(
        <Button onClick={handleClick}>
            {IsSubs? "Отписаться":"Подписаться"}
        </Button>
    )
}