import React, { useState } from "react"
import {Slider} from "./Slider";
import {Grid,Paper} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import {ButtonSettings} from "./ButtonSettings";
import { Ava } from "./Ava";
export const Post=({id, ava,settings,photos=[]})=>{

    let [redirectChange, setChange]=useState(false);

    if(redirectChange) return <Redirect to={"/myprofile/change/"+id}/>

    const handlerChangeClick=()=>{
        setChange(true);
    }
    var setting= settings?<ButtonSettings change={handlerChangeClick}/>:null
    return(
        <Grid item>
            <Paper>
            <Grid
            container
            direction="row"
            justify="space-between"
            alignItems="flex-start"
            >
                    <Ava src={ava}/>
                    {setting}
                </Grid>
                <Slider urls={photos}/>
            </Paper>
        </Grid>
    )
}