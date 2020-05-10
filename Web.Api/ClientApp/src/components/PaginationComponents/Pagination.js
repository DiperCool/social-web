import React, { useState, useEffect } from "react";

export const Pagination=({start,handlerNewPosts, loadComp,isEnd})=>{

    let[page,setPage]=useState(start);
    let[load, setLoad]=useState(true);

    let handler=async()=>{
        setLoad(true);
        await handlerNewPosts(page);
        setPage(page+1);
        setLoad(false);
    }

    useEffect(()=>{
        handler();
    },[])

    return(
        <div>
            {isEnd||load?null:<button onClick={handler}>Загрузить еще</button>}
            {load?loadComp:null}
        </div>
    )
}