 
import React, { useState } from "react";
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import ArrowForwardIcon from '@material-ui/icons/ArrowForward';
import IconButton from '@material-ui/core/IconButton';
import Grid from '@material-ui/core/Grid';
export const Slider=({desc,urls=[],styles={}})=>{


    let [currentImg, setCurrentImg]=useState(0);

    const nextHandler=()=>{
        if(currentImg===urls.length-1){
            setCurrentImg(0);
            return;
        }
        setCurrentImg(currentImg+1);
    }


    const prevHandler=()=>{
        if(currentImg===0){
            setCurrentImg(urls.length-1);
            return;
        }
        setCurrentImg(currentImg-1);
    }

    return(
        <Grid style={{...styles}}
            container
            item
            direction="row"
            style={{display:"relative"}}
            >
            <Grid item style={{margin:"auto 0"}}>
                <IconButton onClick={prevHandler}>
                    <ArrowBackIcon />
                </IconButton>
            </Grid>
            <Grid item>
                <img src={urls.length==0?"":urls[currentImg].urlImg} width="500px" height="500px"></img>
                <br></br>
                {desc}  
            </Grid>     
            <Grid item style={{margin:"auto 0"}}>
                <IconButton onClick={nextHandler}>
                    <ArrowForwardIcon/>
                </IconButton>
            </Grid>
        </Grid>
    )
}