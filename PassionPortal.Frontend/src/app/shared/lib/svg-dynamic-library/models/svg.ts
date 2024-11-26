import { Path } from "./path"
import { SvgProperties } from "./svg.properties"

export interface Svg {
    name: string
    properties: SvgProperties
    childNodes: Array<Path> | null
}