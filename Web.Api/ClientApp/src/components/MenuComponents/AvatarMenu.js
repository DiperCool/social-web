import React, {useState} from "react";
import {Avatar, Menu, MenuItem} from "@material-ui/core";

export const AvatarMenu=({url})=>{


	let [alChaer, setAlChaer]= useState(null);
	const open= Boolean(alChaer);
	const handleMenu = (event) => {
    	setAlChaer(event.currentTarget);
  	};

  const handleClose = () => {
    setAlChaer(null);
  };

	return (
		<div>
			<Avatar onClick={handleMenu} src={url}/>
			<Menu
                anchorEl={alChaer}
                anchorOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                keepMounted
                transformOrigin={{
                  vertical: 'top',
                  horizontal: 'right',
                }}
                open={open}
                onClose={handleClose}
              >
                <MenuItem onClick={handleClose}>Profile</MenuItem>
                <MenuItem onClick={handleClose}>My account</MenuItem>
              </Menu>
		</div>
	)
}