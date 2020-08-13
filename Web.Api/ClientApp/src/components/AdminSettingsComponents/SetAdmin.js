import React, { useRef } from 'react';
import { setAdminGroup } from '../../Api/GroupApi/GroupAdmins/setAdminGroup';


export const SetAdmin=({loginGroup})=>{
    let refLogin=useRef("");
    let refRight=useRef("");
    const setAdmin=async()=>{
        await setAdminGroup(loginGroup,refLogin.current.value,refRight.current.value.split(","));
    }
    return(
        <div>
            <input ref={refLogin} type="text" placeholder="Введите логин"></input>
            <input ref={refRight} type="text" placeholder="Введите права через: ,"></input>
            <button onClick={setAdmin}>click</button>
        </div>
    )
    
}