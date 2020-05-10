import React, { useState } from "react";
import ChatBubbleOutlineIcon from '@material-ui/icons/ChatBubbleOutline';
import IconButton from '@material-ui/core/IconButton';
import { Redirect } from "react-router-dom";

export const CommentsIcon=({login,id})=>{
    
    let [red,setRed]=useState(false);

    const redirect=()=>{
        setRed(true);
    }
    if(red){
        return <Redirect to={`/post/${login}/${id}`}/>
    }
    return(
        <div>
            <IconButton onClick={redirect}>
                <ChatBubbleOutlineIcon />
            </IconButton>
        </div>
    )
}