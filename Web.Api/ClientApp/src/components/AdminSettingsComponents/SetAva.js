import React, { useEffect, useState, useContext, useRef } from 'react';
import { Avatar } from '@material-ui/core';
import { GroupViewContext } from '../GroupComponents/GroupViewComponents/GroupViewContext';
import { setGroupAva } from '../../Api/GroupApi/GroupAdmins/setGroupAva';

export const SetAva=({loginGroup})=>{
    

    let {ava, setAva}=useContext(GroupViewContext);
    let refPhoto= useRef(null);

    const handlerChangeAva=async ()=>{
        
        let photo= refPhoto.current;
        if(photo.files==null) return;
        let formData= new FormData();
        formData.append("photo", photo.files[0]);
        let newPath= await setGroupAva(loginGroup,formData);
        setAva(newPath.urlImg);
        refPhoto.current.value=null;
        
    }
    return(
        <div>
            <Avatar src={ava}/>
            <input type="file" ref={refPhoto} onChange={handlerChangeAva}/>
        </div>
    )
}