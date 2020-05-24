import React,{useState} from "react";
import {IconButton, Menu} from "@material-ui/core";
import { DeleteComment } from "../DeleteComment";
import MoreVertIcon from '@material-ui/icons/MoreVert';
import { CommentChange } from "../CommentChange";
export const CommentsOption=({id, idComment})=>{

    const [anchorEl, setAnchorEl] = React.useState(null);
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };
    
      const handleClose = () => {
        setAnchorEl(null);
      };
      return (
        <div>
            <IconButton onClick={handleClick}>
                <MoreVertIcon/>
            </IconButton>
            <Menu
            anchorEl={anchorEl}
            keepMounted
            open={Boolean(anchorEl)}
            onClose={handleClose}
            >
                <DeleteComment id={id} idComment={idComment} handlerClose={handleClose}/>
                <CommentChange idComment={idComment}/>
            </Menu>
        </div>
      )
}