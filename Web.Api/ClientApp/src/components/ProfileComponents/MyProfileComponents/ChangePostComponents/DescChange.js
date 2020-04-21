import React, { useState,useEffect } from "react";
import { Input } from "@material-ui/core";

export const DescChange=({desc, handlerChange})=>{

    let [text, setText]=useState(desc);
    useEffect(()=>{
        setText(desc);
    }, [desc])
    const handler=(e)=>{
        if(e.keyCode==13){
            console.log(1);
            handlerChange(text);
        }
    }
    return(
        <div>
            <Input value={text} 
                    onChange={(e)=>setText(e.target.value)}
                    placeholder={"Введите новое описание"}
                    onKeyUp={handler}
                    id="standard-basic" 
                    label="Description"/>
        </div>
    )
}