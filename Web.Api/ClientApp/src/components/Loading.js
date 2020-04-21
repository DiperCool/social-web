import React from "react";
import CircularProgress from '@material-ui/core/CircularProgress';
import {CenterComponent} from "./CenterComponent";
export const Loading=()=>{
    return(
        <div>
            <CenterComponent>
                <CircularProgress/>
            </CenterComponent>
        </div>
    )
}