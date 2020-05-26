import React,{useState} from "react";
import {Grid,Menu,MenuItem} from "@material-ui/core"
import MoreVertIcon from '@material-ui/icons/MoreVert';
import IconButton from '@material-ui/core/IconButton';
export const ButtonSettings=({children})=>{

    const [anchorEl, setAnchorEl] = useState(null);

    const handleClick = event => {
      setAnchorEl(event.currentTarget);
    };
  
    const handleClose = () => {
      setAnchorEl(null);
    };
    

    if(children===undefined) return null;
    return(
        <Grid 
        item>
            <IconButton onClick={handleClick}>
                <MoreVertIcon></MoreVertIcon>
            </IconButton>
            <Menu
                id="simple-menu"
                anchorEl={anchorEl}
                open={Boolean(anchorEl)}
                onClose={handleClose}
                >
                {children}
                
            </Menu>
        </Grid>
     )
}