import React from "react";
import ChatBubbleOutlineIcon from '@material-ui/icons/ChatBubbleOutline';
import IconButton from '@material-ui/core/IconButton';
import { Link } from "react-router-dom";

export const CommentsIcon=({login,id})=>{
    

    return(
        <div>
            <Link to={`/post/${login}/${id}`}>
                <IconButton>
                    <ChatBubbleOutlineIcon />
                </IconButton>
            </Link>
            
        </div>
    )
}