import React, {useState, useEffect} from "react";
import {Button, Backdrop, MenuList} from "@material-ui/core";
import { UserView } from "../SearchUsersComponents/UserView";
import { Pagination } from "../PaginationComponents/Pagination";
import { VerticalLoading } from "../VerticalLoading";
let one=false;
export const ViewLikes=({id,func,text})=>{

    let [open, setOpen]=useState(false);
    let [users, setUsers]=useState({
        users:[],
        isEnd:false
    });

    const handleClose=()=>{
        setOpen(false);
    }
    const LoadMoreHandler=async ()=>{
        let res =await func(id,users.users.length===0?0:users.users[users.users.length-1].id);
        setUsers({
            users: [...users.users, ...res.result],
            isEnd:res.isEnd
        })
    }

    const handleOpen=()=>{
        if(users.users.length===0) return;
        setOpen(true)
    }

    return(
        <div>
            <Button 
            onClick={handleOpen}>
                {text}
            </Button>
            <Backdrop open={open} onClick={handleClose} style={{zIndex:2}}>
                <div onClick={e=>{e.stopPropagation()}} style={{background:"white", height:"300px", overflow:"scroll"}}>
                    <MenuList>
                        {users.users.map((el)=><UserView ava={el.user.ava.urlImg} login={el.user.login}/>)}
                        <Pagination  
                            handlerNewPosts={async()=>{
                                await LoadMoreHandler()
                            }} 
                            loadComp={<VerticalLoading/>}
                            isEnd={users.isEnd}/>
                    </MenuList>
                </div>
            </Backdrop>
        </div>
    )
}