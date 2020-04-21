import React from "react";
import Grid from '@material-ui/core/Grid';

export const CenterComponent=({children})=>{
    return (<div>
        <Grid
        container
        spacing={0}
        direction="column"
        alignItems="center"
        justify="center"
        style={{ minHeight: '100vh' }}
        >
            <Grid item xs={3}>
                {children}
            </Grid>   
        </Grid> 
    </div>)
}