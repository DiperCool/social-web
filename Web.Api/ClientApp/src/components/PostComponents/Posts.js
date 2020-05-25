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
    let[page,setPage]=useState(1);
    let[one, setOne]=useState(true);

    const LoadMoreHandler=async(page,reWrite=false)=>{
        setPage(page+1);
        let postsRes= await getPostsUser(login,page);
        let data=postsRes.data
        if(reWrite){
            setPosts({
                posts:[...data.result],
                isEnd: data.isEnd
            })
            return;
        }
        setPosts({
            posts:[...posts.posts, ...data.result],
            isEnd: data.isEnd
        });
    }
    let items=posts.posts.map((el,i)=>
        <Post key={i} photos={el.photos} id={el.id} login={el.user.login} ava={el.user.ava.urlImg} settings={settings}/> )

    console.log(1);
    useEffect(()=>{
        if(one){
            setOne(false);
            return;
        }
        LoadMoreHandler(1,true);
    },[login])
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
                            handlerNewPosts={async()=>{
                                await LoadMoreHandler(page)
                            }} 
                            loadComp={<VerticalLoading/>}
                            isEnd={posts.isEnd}/>
                    </div>
                </Grid>

        </div>
    )
}
