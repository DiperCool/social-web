import React from "react";
import {Avatar} from "@material-ui/core";
import {CenterHorizontal} from '../../CenterHorizontal'
export const Ava=({src})=>{
    

    return(
        <CenterHorizontal>
            <div>
                <Avatar src={src} style={{height:"100px", width:"100px"}}></Avatar>
            </div>
        </CenterHorizontal>
    )
}