export interface IconInterface {
    name: string
    svg: SvgProperties
    path: PathProperties
}

export interface SvgProperties{
    width:string
    height: string
    viewBox: string
    fill: string
}

export interface PathProperties {
    d: string
    stroke: string
    strokeWidth: string
    strokeLinecap: string
    strokeLinejoin: string
}