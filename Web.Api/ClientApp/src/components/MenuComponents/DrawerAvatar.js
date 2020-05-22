import React, {useState} from "react";
import SwipeableDrawer from '@material-ui/core/SwipeableDrawer';
import SearchIcon from '@material-ui/icons/Search';
import {Redirect} from "react-router-dom"
import {IconButton,List, ListItem, ListItemText,ListItemIcon} from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import SettingsIcon from '@material-ui/icons/Settings';
import { SearchUsersComp } from "../SearchUsersComponents/SearchUsersComp";


export const DrawerAvatar=({isAuth})=>{



	let ListYes=[
		{
			text: "My profile",
			icon: <AccountCircleIcon/>,
			handler: ()=>handlerView(<Redirect to="/myprofile"/>)
		},
		{
			text: "Settings",
			icon: <SettingsIcon/>,
			handler: ()=>handlerView(<Redirect to="/profile"/>)
		}
	]

	let ListNo=[
		{
			text: "Login",
			icon: "none",
			handler: ()=>handlerView(<Redirect to="/login"/>)
		},
		{
			text: "Register",
			icon: "none",
			handler: ()=>handlerView(<Redirect to="/register"/>)
		}
	]

	let [open, setOpen]=useState(false);
	let [viewComponent, setViewComponent]= useState({
		view:false,
		comp: null
	});

	const handlerView=(comp, bool=true)=>{
		setViewComponent({
			view:bool,
			comp:comp
		})
		setOpen(false)
	}

	const handler=()=>{
		setOpen(!open);
	}


	const list= isAuth?
                  <List>
					{ListYes.map((el,i)=> <ListItem button key={i} onClick={el.handler}>
					<ListItemIcon>{el.icon=="none"? null:el.icon}</ListItemIcon>
                      <ListItemText primary={el.text}/>
                    </ListItem>)}
                  </List>:
                  <List>
                    {ListNo.map((el, i)=> <ListItem button key={i}>
					<ListItemIcon>{el.icon=="none"? null:el.icon}</ListItemIcon>
                      <ListItemText primary={el.text}/>
                    </ListItem>)}
                  </List>

	return(
		<div>
			{viewComponent.view?viewComponent.comp: null}
			<IconButton 
				edge="start" 
				color="inherit" 
				aria-label="menu"
				onClick={handler}>
                <MenuIcon />
            </IconButton>
			<SwipeableDrawer
			anchor={"left"}
			open={open}
			onClose={handler}
			>
				<div style={{width:"250px"}}>
					{list}	
				</div>
			</SwipeableDrawer>
		</div>
	)
}
