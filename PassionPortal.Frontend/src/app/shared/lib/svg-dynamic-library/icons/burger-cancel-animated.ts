import { Svg } from "../models/svg";
import { ChildNodeType } from "../models/childNode-enum";

export const BurgerCancelAnimated: Svg = {
    name: 'BurgerCancelAnimated',
    properties: {
        width:"800px",
        height:"800px",
        viewBox:"0 0 64 48",
        fill:"none" 
    },
    childNodes:[ {
        type: ChildNodeType.Path,
        d:"M19,15 L45,15 C70,15 58,-2 49.0177126,7 L19,37",
        stroke:null,
        strokeWidth:null,
        strokeLinecap:null, 
        strokeLinejoin: null
        },
        {
        type: ChildNodeType.Path,
        d:"M19,24 L45,24 C61.2371586,24 57,49 41,33 L32,24",
        stroke:null,
        strokeWidth:null,
        strokeLinecap:null, 
        strokeLinejoin: null
        },
        {
        type: ChildNodeType.Path,
        d:"M45,33 L19,33 C-8,33 6,-2 22,14 L45,37",
        stroke:null,
        strokeWidth:null,
        strokeLinecap:null, 
        strokeLinejoin: null
        }
    ]
}

