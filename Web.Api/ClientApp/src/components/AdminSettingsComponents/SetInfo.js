import React, { useEffect, useState, useContext, useRef } from 'react';
import { GroupViewContext } from '../GroupComponents/GroupViewComponents/GroupViewContext';
import { TextField } from '@material-ui/core';
import {setGroupInfo} from "../../Api/GroupApi/GroupAdmins/setGroupInfo";
export const SetInfo=({loginGroup})=>{
    

    const {info, setInfo}=useContext(GroupViewContext);
    const [infoTemp, setInfoTemp]= useState(info);
    const onClick=async ()=>{
        const res= await setGroupInfo(loginGroup, infoTemp);
        setInfo(infoTemp);
    }
    return(
        <div>
           <div>
                <TextField value={infoTemp.name} onChange={(e)=>{setInfoTemp({id:infoTemp.id,name:e.target.value,
                                                                            description:infoTemp.description })}}></TextField>
                <TextField value={infoTemp.description} onChange={(e)=>{setInfoTemp({id:infoTemp.id,name:infoTemp.name ,
                                                                            description:e.target.value})}}></TextField>
                <button onClick={onClick}>Save</button>                                                           
           </div>
        </div>
    )
}