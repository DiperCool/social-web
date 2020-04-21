import React from "react";
import { Alert } from '@material-ui/lab';
export const Error=({Errors, Visible})=>{

    if(!Visible){
        return null;
    }

    return(
        <div style={{"position":"absolute", width:"100%"}}> 
            {Errors.map((el,i)=><Alert key={i} severity={"error"}>{el}</Alert>)}
        </div>
    )
}