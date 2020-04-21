import React from "react";
import Grid from '@material-ui/core/Grid';
export const CenterHorizontal=({children})=>{



    return(
        <Grid 
        container={true}
        direction="row"
        justify="center"
        alignItems="flex-start"
        >
            {children}
        </Grid>
    )
}