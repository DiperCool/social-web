import React,{useContext} from "react";
import {CommentsContext} from "./CommentContext/CommentsContext";
import { MenuItem } from "@material-ui/core";
export const CommentChange=({idComment})=>{

    let {isChange, 
        setIsChange
        }= useContext(CommentsContext)
    
    const handlerClick=()=>{

        console.log(idComment)
        setIsChange({
            idComment:isChange.idComment===idComment?-1:idComment,
            changeMode:isChange.idComment===idComment?false:true
        })
    }
    return (
        <MenuItem onClick={handlerClick}>
            Change
        </MenuItem>
    )
}