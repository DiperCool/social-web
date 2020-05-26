import React, { useState, useEffect } from "react"
import {getPostAnyUser} from "../../Api/PostApi/getPostAnyUser"
import { Post } from "../PostComponents/Post";
import { VerticalLoading } from "../VerticalLoading";
import { Grid } from "@material-ui/core";
import {Comments} from "../CommentsComponents/Comments"
export const PostViewAll=(props)=>{

    let[post, setPost]=useState({});
    let [load, setLoad]=useState(true);

    useEffect(()=>{
        const getPost=async ()=>{
            let res= await getPostAnyUser(props.match.params.id,props.match.params.login);
            setPost(res);
            setLoad(false);
        }
        getPost();
    },[])


    if(load){
        return <VerticalLoading/>
    }

    return(
       <div>
           <Grid container style={{height:"80vh"}}>
               <Grid item> 
                    <Post 
                    id={post.id} 
                    ava={post.user.ava.urlImg} 
                    photos={post.photos} 
                    login={post.user.login} 
                    settings={null}
                    desc={post.description}/>
               </Grid>
               <Grid item>
                    <Comments id={post.id} />
               </Grid>
           </Grid>
       </div> 
    )
}

//id, ava,settings,login,photos=[]