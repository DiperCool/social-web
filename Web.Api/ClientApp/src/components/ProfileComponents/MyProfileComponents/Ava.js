import React from "react";
import {Grid, Avatar} from "@material-ui/core"


export const Ava=({src})=>{

    return(
        <Grid item style={{padding:"10px"}}>
            <Avatar src={src}/>
        </Grid>
    )
}