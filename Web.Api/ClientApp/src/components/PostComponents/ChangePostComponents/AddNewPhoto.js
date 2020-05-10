import React,{useRef} from "react";
import { saveNewPhoto } from "../../../Api/PostApi/saveNewPhoto";

export const AddNewPhoto=({handlerChange, id})=>{
    let photosRef=useRef(null);
    const handler=async()=>{
        let photo= photosRef.current;
        if(photo.files==null){
            return [];
        }
        console.log(photo.files);
        let formData= new FormData();
        formData.append("idPost", id);
        for(let i=0; i<=photo.files.length; i++){
            formData.append("imgs", photo.files[i]);
        }
        photosRef.current.value=null;
        let photos=await saveNewPhoto(formData);
        handlerChange(photos.result);
    }
    return(
        <div>
            <input type="file" multiple ref={photosRef} onChange={handler}/>
        </div>
    )
}