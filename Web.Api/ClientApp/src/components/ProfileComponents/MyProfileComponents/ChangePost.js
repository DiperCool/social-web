import React, { useEffect, useState } from "react";
import {getPostUser} from "../../../Api/ProfileApi/getPostUser"
import {deltePhotoInPosts} from "../../../Api/ProfileApi/deltePhotoInPosts"
import { DescChange } from "./ChangePostComponents/DescChange";
import { changeDesc } from "../../../Api/ProfileApi/changeDesc";
import { AddNewPhoto } from "./ChangePostComponents/AddNewPhoto";
import { Photos } from "./ChangePostComponents/Photos";
import {Loading} from "../../Loading";
export const ChangePost=(props)=>{

    let [checkedPhoto, setCheckedPhoto]=useState([]);
    let [photos, setPhotos]= useState([]);
    let [desc, setDesc]=useState("");
    let [isLoad, setLoad]=useState(false);
    const handlerClick=(id)=>{
        let i=checkedPhoto.indexOf(id);
        if(i>=0){
            setCheckedPhoto(checkedPhoto.filter(x=>x!==id))
            return;
        }
        setCheckedPhoto([...checkedPhoto, id]);
    }

    useEffect(()=>{
        const getPhotos=async()=>{
            let res=await getPostUser(props.match.params.id);
            setDesc(res.result.description);
            setPhotos(res.result.photos);
            setLoad(true);
        }
        getPhotos();
    },[])

    const handlerDeletePhoto=async()=>{
        await deltePhotoInPosts(checkedPhoto, props.match.params.id)
        setPhotos(photos.filter((x)=>{
            return checkedPhoto.indexOf(x.id)===-1;
        }));
    }

    const handlerChangeDesc=(text)=>{
        changeDesc(text,props.match.params.id);
    }
    const handlerNewPhoto=(img)=>{
        setPhotos([...photos, ...img]);
    }

    if(!isLoad){
        return <Loading/>
    }

    return(
        <div>
            <DescChange desc={desc} handlerChange={handlerChangeDesc}/>
            <Photos photos={photos} handler={handlerClick} CheckedPhoto={checkedPhoto}/>
            <AddNewPhoto id={props.match.params.id} handlerChange={handlerNewPhoto}/>
            <button onClick={handlerDeletePhoto}>Отправить</button>
        </div>
    )
}