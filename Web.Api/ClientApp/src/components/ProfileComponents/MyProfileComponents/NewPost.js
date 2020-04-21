import React,{useRef} from "react";
import {saveNewPost} from "../../../Api/ProfileApi/saveNewPost";
export const NewPost=()=>{

    let inputRef=useRef(null);
    let photosRef=useRef(null);
    const handler=async()=>{
        let desc= inputRef.current.value;
        let photo= photosRef.current;
        if(photo.files==null) return;
        console.log(photo.files);
        let formData= new FormData();
        formData.append("Description", desc);
        for(let i=0; i<=photo.files.length; i++){
            formData.append("Photos", photo.files[i]);
        }
        await saveNewPost(formData);
    }
    return(
        <div>
            <input placeholder="Добавте описание" ref={inputRef} type="text"/>
            <input type="file" multiple ref={photosRef}/>
            <button onClick={handler}>Отправить</button>
        </div>
    )
}