import React, { useState, useEffect, useRef, useContext } from 'react';
import { SettinsAdmin } from '../../AdminSettingsComponents/SettingsAdmin';
import { groupGet } from '../../../Api/GroupApi/Group/GroupGet';
import { GroupViewContext } from './GroupViewContext';
import { Loading } from '../../Loading';
import { Avatar } from '@material-ui/core';
export const GroupViewComponent=({match})=>{

    let [info, setInfo]=useState(null);
    let[ava, setAva]= useState(null);
    useEffect(()=>{
        const getGroup=async()=>{
            let res=await groupGet(match.params.login);
            setInfo(res.info);
            setAva(res.ava.urlImg);
        }
        getGroup();
    },[])
    if(info===null||ava===null){
        return <Loading/>
    }
    return(
        <div>
            <div>
                <Avatar src={ava}></Avatar>
                <div>
                    {info.name}
                </div>
                <br></br>
                <div>
                    {info.description}
                </div>
                <GroupViewContext.Provider value={{info,ava,setInfo,setAva}}>
                    <SettinsAdmin loginGroup={match.params.login}/>
                </GroupViewContext.Provider>
            </div>
        </div>
    )
}