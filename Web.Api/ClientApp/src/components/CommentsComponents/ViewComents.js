import React, { useState, useContext } from "react";
import {getComments} from "../../Api/CommentsApi/getComments"
import {CommentsContext} from "./CommentContext/CommentsContext"
import {Comment} from "./Comment";
import { Pagination } from "../PaginationComponents/Pagination";
import { VerticalLoading } from "../VerticalLoading";
import { Grid } from "@material-ui/core";
import {FindDuplicate} from "../FindDuplicate"
export const ViewComents=({id})=>{
    let{setComments,comments, idAddedComments}= useContext(CommentsContext);

    let [load, setLoad]=useState({
        isEnd:false,
        load:true
    });

    const getNewsId=(arr, callback)=>{
        let newArr=[]
        arr.forEach(el => newArr.push(callback(el)));
        return newArr;
    }

    const handlerNewComments=async(page)=>{
        setLoad({
            isEnd:load.isEnd,
            load:true
        })
        let res=await getComments(id, page);
        //соединение массивов с новыми id и id которые были созданные
        let arrIds=getNewsId(res.result, x=>x.id)
        //чтобы не выводились коментарие которые были добавлены
        arrIds= idAddedComments.concat(arrIds);
        //поиск дубликатов
        arrIds=arrIds.filter(FindDuplicate)
        //удаление дубликата
        let result= res.result.filter(el=>arrIds.indexOf(el.id)===-1)
        setComments([...comments, ...result])
        setLoad({
            isEnd:res.isEnd,
            load:false
        })
    }


    let ViewComents=comments.map(el=><Comment
                                        key={el.id}
                                        who={el.author.login} 
                                        ava={el.author.ava.urlImg} 
                                        content={el.content}
                                        id={id}
                                        idComment={el.id}/>)


    return(
        <div style={{marginLeft:"20px"}}>
            <Grid 
                container
                direction="column"
                justify="flex-start"
                alignItems="flex-start"
                spacing={2}>
                {ViewComents}
            </Grid>
            <Pagination 
                start={1} 
                handlerNewPosts={handlerNewComments} 
                loadComp={<VerticalLoading/>}
                isEnd={load.isEnd}/>
        </div>
    )
}
