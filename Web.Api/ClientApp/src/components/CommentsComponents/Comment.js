import React from "react"
import { Grid, Card, Avatar, CardContent, CardHeader } from "@material-ui/core"
import { CommentsOption } from "./CommentsOption/CommentsOprion";
export const Comment=({who, content, to,ava, idComment,id})=>{


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
            </Card>
        </Grid>
    )
}

//style={{padding:"10px", wordWrap:"break-word", width:"300px", overflow:'hidden'}}