import React, { useState, useEffect, useRef, useContext } from 'react';
import { getRigthGroup } from '../../../Api/GroupApi/GroupAdmins/getRigthGroup';
import {setAdminGroup} from '../../../Api/GroupApi/GroupAdmins/setAdminGroup';
import { UserContext } from '../../UserComponent/UserContext';
export const GroupViewComponent=({match})=>{

    let [rigths, setRigths]= useState("None");
    let refLogin=useRef("");
    let refRight=useRef("");
    let {Auth}= useContext(UserContext);
    let rigthsList={
        "Creator":0,
        "Moderator":1,
        "None":2
    }
    useEffect(()=>{
        let getRigths=async()=>{
            let res=await getRigthGroup(match.params.login, Auth.login);
        }
        getRigths();
    },[])

    const setAdmin=async()=>{
        await setAdminGroup(match.params.login,refLogin.current.value,refRight.current.value.split(","));
    }
    return(
        <div>
            {rigthsList[rigths]!==2?<button>Manage group</button>:null}
            <div>
                <input ref={refLogin} type="text" placeholder="Введите логин"></input>
                <input ref={refRight} type="text" placeholder="Введите права через: ,"></input>
                <button onClick={setAdmin}>click</button>
            </div>
        </div>
    )
}