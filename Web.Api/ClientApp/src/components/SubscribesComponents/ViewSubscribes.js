import React, {useState, useEffect} from "react";
import {Button, Backdrop, MenuList} from "@material-ui/core";
import { UserView } from "../SearchUsersComponents/UserView";
import { Pagination } from "../PaginationComponents/Pagination";
import { VerticalLoading } from "../VerticalLoading";

export const ViewSubscribes=({login,func,text})=>{

    let [open, setOpen]=useState(false);
    let [Login, setLogin]= useState("");
    let [page, setPage]=useState(1);
    let [posts, setPosts]=useState({
        posts:[],
        isEnd:false
    });
    let [one, setOne]= useState(false);


    useEffect(()=>{
        
        const getAll=async()=>{
            if(!one){
                setOne(true);
                return;
            }
            let res=await func(login, 1);
            setLogin(login);
            setPosts({
                posts:res.result,
                isEnd:res.isEnd
            });
            setPage(1);
        }
        getAll();
    },[login])

    const handleClose=()=>{
        setOpen(false);
    }
    const LoadMoreHandler=async (page)=>{
        let res =await func(login, page);
        setPosts({
            posts: [...posts.posts, ...res.result],
            isEnd:res.isEnd
        })
        setPage(page+1);
    }

    const handleOpen=()=>{
        if(posts.posts.length===0) return;
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
                        {posts.posts.map((el)=><UserView ava={el.ava.urlImg} login={el.login}/>)}
                        <Pagination  
                            handlerNewPosts={async()=>{
                                await LoadMoreHandler(page)
                            }} 
                            loadComp={<VerticalLoading/>}
                            isEnd={posts.isEnd}/>
                    </MenuList>
                </div>
            </Backdrop>
        </div>
    )
}