import React from "react";
import { Menu } from "./Menu";

export const ViewMenuWithComponent=(props)=>{

    return (
        <div>
            <Menu />
            {props.Comp}
        </div>
    )
}