import { Injectable } from "@angular/core";
import { Svg } from "../models/svg";
import { iconList } from "../icons.config";



@Injectable({
    providedIn: 'root',
})
export class SvgService {
    iconsList?: Array<Svg>

    loadIcons() {
        this.iconsList = iconList
    }

    getIcon(name: string) {
        return this.iconsList?.find(x => x.name == name)
    }
}