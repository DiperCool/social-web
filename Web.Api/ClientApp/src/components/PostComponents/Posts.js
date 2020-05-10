import React,{useState, useEffect} from "react";
import {Grid} from "@material-ui/core"
import {Post} from "./Post";
import {getPostsUser} from "../../Api/PostApi/getPostsUser";
import { VerticalLoading } from "../VerticalLoading";
import { Pagination } from "../PaginationComponents/Pagination";
export const Posts=({settings,login})=>{
    let [posts, setPosts]= useState({
        posts:[],
        isEnd:false
    });
    const LoadMoreHandler=async(page)=>{
        let postsRes= await getPostsUser(login,page);
        let data=postsRes.data
        setPosts({
            posts:[...posts.posts, ...data.result],
            isEnd: data.isEnd
        });
    }
    let items=posts.posts.map((el,i)=>
        <Post key={i} photos={el.photos} id={el.id} login={el.user.login} ava={el.user.ava.urlImg} settings={settings}/> )
    return(
        <div>
            <Grid
                container
                direction="column"
                justify="center"
                alignItems="center"
                >
                    <div>
                        {items}
                        <Pagination 
                            start={1} 
                            handlerNewPosts={LoadMoreHandler} 
                            loadComp={<VerticalLoading/>}
                            isEnd={posts.isEnd}/>
                    </div>
                </Grid>

        </div>
    )
}
