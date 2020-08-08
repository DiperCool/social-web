import React, {useContext} from "react";
import { MenuItem } from "@material-ui/core";
import {deleteComment} from "../../Api/CommentsApi/deleteComment";
import {CommentsContext} from "./CommentContext/CommentsContext";
export const DeleteComment=({handlerClose, id,idComment})=>{


    let {comments,setComments}=useContext(CommentsContext);
    const deleteCommentHandler=async()=>{
        await deleteComment(id, idComment);
        setComments(comments.filter(x=>x.comment.id!==idComment));
        handlerClose();
    }


    return(
        <MenuItem onClick={deleteCommentHandler}>
            Delete
        </MenuItem>
    )
} 