import React, { useState, useEffect } from "react"
import {Grid,Avatar} from "@material-ui/core"
import { CenterHorizontal } from "../../CenterHorizontal"
export const InfoUser=({login, ava, about})=>{



    return (
        <Grid container direction={"row"}>
            <Grid item>
                <Avatar src={ava} style={{height:"150px",width:"150px"}}/>
            </Grid>
            <Grid item>
                <div>{login}</div>
                <br/>
                <div>{about}</div>
            </Grid>
        </Grid>
    )


}