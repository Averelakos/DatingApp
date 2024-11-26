import { Injectable } from "@angular/core";
import { MenuItem } from "../../shared/models/menu/menu-item";
import { welcomeMenuItems } from "../misc/welcome-menu";

@Injectable({
    providedIn: 'root'
})
export class MenuService{

    public getWelcomeMenuItems(): MenuItem[] {
        return welcomeMenuItems
    }
}