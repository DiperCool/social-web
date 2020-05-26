import React from "react"
import {Slider} from "./Slider";
import {Link} from "react-router-dom";
import {Grid,Paper,MenuItem} from "@material-ui/core";
import {ButtonSettings} from "./PostSettings/ButtonSettings";
import {CommentsIcon} from "../CommentsComponents/CommentsIcon";
import { Ava } from "../ProfileComponents/MyProfileComponents/Ava";
export const Post=({id, ava,upPanel, downPanel,login,desc,photos=[]})=>{

    let UpPanel={
        "withSettings":
        <div>
            <Link to={"/post/change/"+id} style={{textDecoration: "none", color:"black"}}>
                <MenuItem>Change</MenuItem>
            </Link>
            <MenuItem onClick={()=>{}}>
                Delete
            </MenuItem>
        </div>,
        "noSettings":null
    }
    let DownPanel={
        "withComment":<CommentsIcon id={id} login={login}/>,
        "noComments":null
    }



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
                        <ButtonSettings>
                            {UpPanel[upPanel]}
                        </ButtonSettings>
                    </Grid>
                </Grid>
                <Slider urls={photos} desc={desc}/>
                <Grid container>
                    <Grid container>
                        {DownPanel[downPanel]}
                    </Grid>
                </Grid>
            </Paper>
        </Grid>
    )
}
