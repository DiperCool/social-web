import React, { useState } from 'react'
import FavoriteIcon from '@material-ui/icons/Favorite';
import {IconButton} from "@material-ui/core";
import FavoriteBorderIcon from '@material-ui/icons/FavoriteBorder';
import {setLikePost} from "../../Api/LikeApi/setLikePost";
import {unLikePost} from "../../Api/LikeApi/unLikePost";
export const Like = ({id,isLike=false}) => {
    let[like,setLike]=useState(isLike);

    const toggleLike=async()=>{
        if(like){
            await unLikePost(id);
        }else{
            await setLikePost(id);
        }   
        setLike(!like);
    }

    return (
        <div>
            <IconButton onClick={toggleLike}>
                {like?<FavoriteIcon style={{color:"red"}}/>:<FavoriteBorderIcon/>}
            </IconButton>
        </div>
    )
}
