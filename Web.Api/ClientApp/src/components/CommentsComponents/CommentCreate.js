import React, {useRef, useContext} from "react";
import {newComment} from "../../Api/CommentsApi/newComment"
import {changeComment} from "../../Api/CommentsApi/changeComment"
import{CommentsContext} from "./CommentContext/CommentsContext"
import { TextField } from "@material-ui/core";
export const CommentCreate=({id})=>{

    let {comments, 
        setComments, 
        idAddedComments,
        setIdAdeddedComments,
        isChange, 
        setIsChange
        }= useContext(CommentsContext)
    let refInput=useRef(null);

    const handler=async (e)=>{
        if(e.keyCode===13){
            let content=refInput.current.value;
            if(!isChange.changeMode){
                let res=await newComment(id, content);
                setComments([...comments, {comment:res, isLike:false}])
                refInput.current.value=null;
                setIdAdeddedComments([...idAddedComments, res.id])
                return;
            }
            await changeComment(id,isChange.idComment, content);
            let arr= comments.map(el=>{
                if(el.comment.id===isChange.idComment){
                    el.comment.content=content;
                }
                return el;
            })
            setComments(arr);
            refInput.current.value=null;
            setIsChange({
                idComment:0,
                changeMode:false
            })
            
        }
    }

    return(
        <div>
            <TextField 
            inputRef={refInput} 
            onKeyDown={handler} 
            placeholder={isChange.changeMode?"Введите новый текст":"Введите текст"}
            variant="outlined" />
        </div>
    )
}
