import React, { useState } from 'react'
import FavoriteIcon from '@material-ui/icons/Favorite';
import {IconButton} from "@material-ui/core";
import FavoriteBorderIcon from '@material-ui/icons/FavoriteBorder';
export const Like = ({id,setLike,unLike,style={},isLike=false}) => {
    let[like,SetLike]=useState(isLike);

    const toggleLike=async()=>{
        if(like){
            await unLike(id);
        }else{
            await setLike(id);
        }   
        SetLike(!like);
    }

    return (
        <div>
            <IconButton onClick={toggleLike}>
                {like?<FavoriteIcon style={{color:"red", ...style}}/>:<FavoriteBorderIcon style={{...style}}/>}
            </IconButton>
        </div>
    )
}
