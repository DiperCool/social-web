import React from "react";
import { Grid } from "@material-ui/core";

export const ImgDelete=({id, handlerClick, refImg, blackout})=>{
    return(
        <Grid item xs={3} lg={2}>
            <img 
                src={refImg} 
                onClick={()=>handlerClick(id)} 
                width={"175px"} 
                height={"175px"} 
                style={{opacity:blackout?0.5: 1}}/>
        </Grid>
    )
}