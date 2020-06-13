import React,{useState, useEffect} from "react";
import {Grid, MenuItem} from "@material-ui/core"
import {Post} from "./Post";
import {getPostsUser} from "../../Api/PostApi/getPostsUser";
import { VerticalLoading } from "../VerticalLoading";
import { Pagination } from "../PaginationComponents/Pagination";
export const Posts=({login, typeUpPanel, typeDownPanel})=>{
    let [posts, setPosts]= useState({
        posts:[],
        isEnd:false
    });
    let[page,setPage]=useState(1);
    let[one, setOne]=useState(true);







    const LoadMoreHandler=async(id,reWrite=false)=>{
        let postsRes= await getPostsUser(login,id);
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
        <Post key={i} 
        photos={el.photos} 
        id={el.id} 
        login={el.user.login} 
        ava={el.user.ava.urlImg} 
        upPanel={typeUpPanel}
        downPanel={typeDownPanel}
        desc={el.description}/>)

    useEffect(()=>{
        if(one){
            setOne(false);
            return;
        }
        setPosts({
            posts:[],
            isEnd:false
        })
        console.log(login);
        LoadMoreHandler(0,true); 
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
                                await LoadMoreHandler(posts.posts.length===0?0:posts.posts[posts.posts.length-1].id)
                            }} 
                            loadComp={<VerticalLoading/>}
                            isEnd={posts.isEnd}/>
                    </div>
                </Grid>

        </div>
    )
}