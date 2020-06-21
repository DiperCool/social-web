import React from "react"
import { Grid, Card, Avatar, CardContent, CardHeader, CardActions } from "@material-ui/core"
import { CommentsOption } from "./CommentsOption/CommentsOprion";
import {Like} from "../LikeComponents/Like";
import { setLikeComment } from "../../Api/LikeApi/setLikeComment";
import { unLikeComment } from "../../Api/LikeApi/unLikeComment";
import { ViewLikes } from "../LikeComponents/ViewLikes";
import { getLikesComment } from "../../Api/LikeApi/getLikesComment";
export const Comment=({who, content, to,ava, idComment,id,isLike})=>{


    return(
        <Grid item>
            <Card style={{width:"300px"}}>
                <CardHeader 
                    style={{padding:"10px"}}
                    avatar={
                        <Avatar src={ava}/>
                    }
                    action={
                        <CommentsOption idComment={idComment} id={id}/>
                    }
                    subheader={to===undefined?null:`Ответ ${to}`}
                    title={<strong style={{fontSize:"18px"}}>{who}</strong>}
                />
                <CardContent style={{padding:"10px"}}>
                    {(to===undefined?"":`${to},`)+content}
                </CardContent>
                <CardActions style={{padding:"0px"}}>
                    <Like 
                        style={{fontSize:"20px"}} 
                        isLike={isLike} 
                        setLike={setLikeComment} 
                        unLike={unLikeComment}
                        id={idComment}/>
                    <ViewLikes id={idComment} func={getLikesComment} text={"Likes"}/>
                </CardActions>
            </Card>
        </Grid>
    )
}

//style={{padding:"10px", wordWrap:"break-word", width:"300px", overflow:'hidden'}}