import React, { useState } from "react"
import {Slider} from "./Slider";
import {Grid,Paper} from "@material-ui/core";
import {Redirect} from "react-router-dom";
import {ButtonSettings} from "./PostSettings/ButtonSettings";
import { Ava } from "../ProfileComponents/MyProfileComponents/Ava";
import { CommentsIcon } from "../CommentsComponents/CommentsIcon";
export const Post=({id, ava,settings,login,photos=[]})=>{

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
                    <Grid item>
                        <Grid container>
                            <Ava src={ava}/>
                            <strong style={{paddingTop:'15px'}}>{login}</strong>
                        </Grid>
                    </Grid>
                    <Grid item>
                        {setting}
                    </Grid>
                </Grid>
                <Slider urls={photos}/>
                <Grid>
                    <CommentsIcon id={id} login={login}/>
                </Grid>
            </Paper>
        </Grid>
    )
}