import { ChildNodeType } from "./childNode-enum"

export interface Path{
    type: ChildNodeType.Path
    d: string | null
    stroke: string | null
    strokeWidth: string | null
    strokeLinecap: string | null
    strokeLinejoin: string | null
}