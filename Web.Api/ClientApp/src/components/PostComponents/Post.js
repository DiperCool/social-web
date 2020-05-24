import React, { useState } from "react"
import {Slider} from "./Slider";
import {Grid,Paper,MenuItem} from "@material-ui/core";
import {Link} from "react-router-dom";
import {ButtonSettings} from "./PostSettings/ButtonSettings";
import { Ava } from "../ProfileComponents/MyProfileComponents/Ava";
import { CommentsIcon } from "../CommentsComponents/CommentsIcon";
export const Post=({id, ava,settings,login,photos=[]})=>{
    const Change=()=>(
        <Link to={"/post/change/"+id} style={{textDecoration: "none", color:"black"}}>
            <MenuItem>Change</MenuItem>
        </Link>
    )


    var setting= settings?<ButtonSettings Change={Change}/>:null
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