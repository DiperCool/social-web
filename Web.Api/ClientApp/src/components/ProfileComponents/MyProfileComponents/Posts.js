import React,{useState, useEffect} from "react";
import {Grid} from "@material-ui/core"
import {Post} from "./Post";
import {getPostsUser} from "../../../Api/ProfileApi/getPostsUser";
import InfiniteScroll from 'react-infinite-scroller';
import { VerticalLoading } from "../../VerticalLoading";
export const Posts=({login,ava,settings})=>{
    let [posts, setPosts]=useState([]);
    let [pagEnd, setPagEnd]=useState(false);
    let [load,setLoad]=useState(false);

    useEffect(()=>{
        const loadPosts=async()=>{
            await LoadMoreHandler(1);
            setLoad(true);
        }
        loadPosts();
    },[]);

    const LoadMoreHandler=async(page)=>{
        let postsRes= await getPostsUser(login,page);
        setPagEnd(postsRes.data.isEnd);
        if(postsRes.data.isEnd){
            return;
        }
        setPosts([...posts, ...postsRes.data.posts]);
    }


    if(!load) return <VerticalLoading/>

    return(
        <div>
            <InfiniteScroll
                 pageStart={1}
                 loadMore={LoadMoreHandler}
                 hasMore={!pagEnd}
                 loader={<div>загрузка</div>}>
                    <Grid
                        container
                        direction="column"
                        justify="center"
                        alignItems="center"
                        spacing={2}
                        >{posts.map(el=>
                        <Post key={el.id} photos={el.photos} id={el.id} ava={ava} settings={settings}/> )}</Grid>
                </InfiniteScroll>
        </div>
    )
}