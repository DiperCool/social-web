import React, { useState, useEffect } from "react";

export const Pagination=({handlerNewPosts, loadComp,isEnd})=>{

    let[load, setLoad]=useState(true);

    let handler=async()=>{
        setLoad(true);
        handlerNewPosts();
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