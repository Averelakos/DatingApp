export enum MenuItemType {
    Link
}

export interface MenuItem {
    type: MenuItemType
    label?: string
    link?: string
}