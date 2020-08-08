import React, { useState } from "react"
import {TextField, Button} from "@material-ui/core";
import {groupCreate} from "../../../Api/GroupApi/GroupCreate/groupCreate";
export const GroupCreate=()=>{


    let [info, setInfo]= useState({
        login:"",
        name:""
    })
    let onClick=()=>{
        groupCreate(info.login, info.name);
    }
    return(
        <div>
            <TextField id="standard-basic" label="Логин группы" onChange={(e)=>setInfo({login:e.target.value, name:info.name})}/>
            <br></br>
            <TextField id="standard-basic" label="Название группы" onChange={(e)=>setInfo({name:e.target.value, login:info.login})}/>
            <br></br>
            <Button variant="contained" color="primary" onClick={onClick}>Создать</Button>

        </div>
    )
}