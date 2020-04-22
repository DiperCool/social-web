import React from "react";
import { Menu } from "./Menu";

export const ViewMenuWithComponent=({comp, routerInfo})=>{

    return (
        <div>
            <Menu />
            {comp}
        </div>
    )
}