import { Injectable } from "@angular/core";
import { IconInterface } from "./icon";
import { iconList } from "./icons.config";

@Injectable({
    providedIn: 'root',
})
export class IconService {
    iconsList?: Array<IconInterface>

    loadIcons() {
        this.iconsList = iconList
    }

    getIcon(name: string) {
        return this.iconsList?.find(x => x.name == name)
    }
}