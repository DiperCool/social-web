import React, { useState } from "react";
import {CommentCreate} from "./CommentCreate";
import {CommentsContext} from "./CommentContext/CommentsContext"
import {ViewComents} from "./ViewComents"
export const Comments=({id})=>{
    let [isChange, setIsChange]=useState({
        idComment:0,
        changeMode:false
    })
    let[comments, setComments]=useState([]);
    let [idAddedComments, setIdAdeddedComments]=useState([]);

    return(
        <CommentsContext.Provider value={{comments,
                                        setComments,
                                        idAddedComments, 
                                        setIdAdeddedComments,
                                        isChange, 
                                        setIsChange}}>
            <div style={{height:"585px", width:"500px",overflow:"scroll"}}>
                <ViewComents id={id} />
            </div>
            <CommentCreate id={id} />
        </CommentsContext.Provider>
    )

}