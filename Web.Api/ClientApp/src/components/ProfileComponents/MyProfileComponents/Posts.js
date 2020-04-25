import React,{useState, useRef, useEffect} from "react";
import {Grid} from "@material-ui/core"
import {Post} from "./Post";
import {getPostsUser} from "../../../Api/ProfileApi/getPostsUser";
import { VerticalLoading } from "../../VerticalLoading";
export const Posts=({login,ava,settings})=>{
    let [posts, setPosts]= useState({
        page:1,
        posts:[],
        isEnd:false,
    });
    let [load,setLoad]=useState(true);
    const LoadMoreHandler=(bool=false)=>{
        setLoad(true);
        let postsRes= getPostsUser(login,bool?1:posts.page);
        postsRes.then((data)=>{
            data=data.data
            setLoad(false);
            setPosts({
                posts:[...posts.posts, ...data.result],
                isEnd: data.isEnd,
                page:posts.page+1
            });
        })
    }
    useEffect(()=>{
        LoadMoreHandler(true);
    },[])
    let items=posts.posts.map((el,i)=>
        <Post key={i} photos={el.photos} id={el.id} ava={ava} settings={settings}/> )
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
                        {posts.isEnd||load?null:<button onClick={()=>LoadMoreHandler()}>Загрузить еще</button>}
                        {load?<VerticalLoading/>:null}
                    </div>
                </Grid>

        </div>
    )
}