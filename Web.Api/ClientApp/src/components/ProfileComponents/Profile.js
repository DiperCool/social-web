import React, { useEffect, useState, useRef, useContext } from "react";
import profileApi from "../../Api/ProfileApi/getProfile";
import {updateAva} from "../../Api/ProfileApi/getUpdateAva";
import {ProfileContext} from "./Context/contextProfile";
import {Ava} from "./ProfileComponents/Ava"
import {UserInfo} from "./ProfileComponents/UserInfo";
import {udpateUserInfo} from "../../Api/ProfileApi/updateUserInfo";
import CircularProgress from '@material-ui/core/CircularProgress';
import {CenterComponent} from "../CenterComponent";

export const Profile=()=>{

    let [load, setLoad]= useState(false);
    let [ava,setAva]= useState("");
    let [profile, setProfile]=useState({
        aboutMe:"",
        name:"",
        id:2
    });
    let refPhoto=useRef(null);


    useEffect(()=>{
        const getProfile=async()=>{
            let data=await profileApi.getProfile();
            setAva(data.result.ava.urlImg);
            setProfile(data.result.infoUser);
            setLoad(true);
        }
        getProfile();
    },[])

    const handlerChangeAva=async ()=>{
        
        let photo= refPhoto.current;
        if(photo.files==null) return;
        let formData= new FormData();
        formData.append("uploads", photo.files[0]);
        let newPath= await updateAva(formData);
        setAva(newPath);
        refPhoto.current.value=null;
        
    }

    const handlerSaveUserInfo=async(id,name,aboutme,gender="Мужик")=>{
        let data= await udpateUserInfo(id,name, aboutme, gender);
        console.log(data);
    }


    if(!load){
        return(<div>
            <CenterComponent>
                <CircularProgress/>
            </CenterComponent>
        </div>)
        
        
    }

    return(
        <CenterComponent>
            <ProfileContext.Provider value={{handlerSaveUserInfo,profile}}>
            <div>
                <div>
                    <Ava src={ava}/>
                    <input type="file" ref={refPhoto} multiple onChange={handlerChangeAva}/>
                </div>
                <div>
                    <UserInfo aboutme={profile.aboutMe} name={profile.name} id={profile.id} gender={profile.gender}/>
                </div>
            </div>
        </ProfileContext.Provider>
        </CenterComponent>
    )
}