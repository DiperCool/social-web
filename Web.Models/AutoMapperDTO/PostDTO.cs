using System;
using System.Collections.Generic;

namespace Web.Models.AutoMapperDTO
{
    public class PostDTO
    {
        public int Id{get;set;}
        public string Description{get;set;}
        public List<ImgDTO> Photos{get;set;}= new List<ImgDTO>();
        public string UserLogin{get;set;}
    }
}