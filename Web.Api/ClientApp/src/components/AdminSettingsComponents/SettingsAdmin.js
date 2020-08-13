import React, { useState, useEffect, useContext } from 'react';
import { Backdrop } from '@material-ui/core';
import { UserContext } from '../UserComponent/UserContext';
import { getRigthGroup } from '../../Api/GroupApi/GroupAdmins/getRigthGroup';
import { SetAdmin } from './SetAdmin';
import { SetAva } from "./SetAva";
import { SetInfo } from "./SetInfo";
export const SettinsAdmin=({loginGroup})=>{
    


    const [view, setView]=useState(false);
    const [right, setRight]=useState([]);
    let {Auth}= useContext(UserContext);
    let rigthsList={
        "ChangeGroupInfo": <SetAva loginGroup={loginGroup}/>,
        "CreatePost":<SetInfo loginGroup={loginGroup}/>,
        "ChangeRightAdmin":<SetAdmin loginGroup={loginGroup}/>
    }
    useEffect(()=>{
        let getRigths=async()=>{
            let res=await getRigthGroup(loginGroup, Auth.login);
            setRight(res);
            
        }
        getRigths();
    },[])
    const closeView=()=>{
        setView(false);
    }
    const openView=()=>{
        setView(true);
    }
    return(
        <div>
            <button onClick={openView}>Manage Group</button>
            <Backdrop open={view} style={{zIndex:2}} onClick={closeView}>

                <div style={{backgroundColor:"white", zIndex:4, padding:"10px"}} onClick={(event)=>{ event.stopPropagation(); }}>
                    {right.map(el=>rigthsList[el])}
                </div>
            </Backdrop>
        </div>
    )
}