import { MenuItem, MenuItemType } from "../../shared/models/menu/menu-item";

export const welcomeMenuItems: Array<MenuItem> = [
    {
        type: MenuItemType.Link,
        label: 'Home',
        link: ''
    },
    {
        type: MenuItemType.Link,
        label: 'Mission',
        link: 'mission'
    },
    {
        type: MenuItemType.Link,
        label: 'Labs',
        link: 'labs'
    },
    {
        type: MenuItemType.Link,
        label: 'Safety',
        link: 'safety'
    },
    {
        type: MenuItemType.Link,
        label: 'Support',
        link: 'support'
    },
    {
        type: MenuItemType.Link,
        label: 'Careers',
        link: 'careers'
    },
]