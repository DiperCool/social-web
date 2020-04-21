import React from "react";
import { Grid } from "@material-ui/core";
import CircularProgress from '@material-ui/core/CircularProgress'

export const VerticalLoading=()=>{

    return(
        <Grid
        container
        direction="row"
        justify="center"
        alignItems="flex-start"
        >
            <CircularProgress/>
        </Grid>
    )
}