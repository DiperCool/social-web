import React from "react"
import {Grid} from "@material-ui/core";
import { ImgDelete } from "./ImgDelete";
export const Photos=({CheckedPhoto,photos=[],handler})=>{

    return(
        <Grid  container>
                {photos.map(el=> <ImgDelete 
                                    id={el.id} 
                                    key={el.id} 
                                    refImg={el.urlImg} 
                                    handlerClick={handler} 
                                    blackout={CheckedPhoto.indexOf(el.id)>=0}/>)}
        </Grid>
    )
}