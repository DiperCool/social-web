import React from "react"
import {Slider} from "./Slider";
import {Link} from "react-router-dom";
import {Grid,Paper,MenuItem} from "@material-ui/core";
import {ButtonSettings} from "./PostSettings/ButtonSettings";
import {CommentsIcon} from "../CommentsComponents/CommentsIcon";
import { Ava } from "../ProfileComponents/MyProfileComponents/Ava";
import { Like } from "../LikeComponents/Like";
import {setLikePost} from "../../Api/LikeApi/setLikePost";
import {unLikePost} from "../../Api/LikeApi/unLikePost";
export const Post=({id, ava,upPanel, downPanel,login,desc,isLike,photos=[]})=>{

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
        "withComment":(
            <Grid container>
                <Grid item>
                    <Like id={id} isLike={isLike} setLike={setLikePost} unLike={unLikePost}/>
                </Grid>
                <Grid item>
                    <CommentsIcon id={id} login={login}/>
                </Grid>
            </Grid>
        ),
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
                    {DownPanel[downPanel]}
                </Grid>
            </Paper>
        </Grid>
    )
}
