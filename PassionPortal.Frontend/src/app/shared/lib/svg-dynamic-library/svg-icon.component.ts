import { AfterViewInit, Component, ElementRef, inject, Input, ViewChild } from '@angular/core';
import { SvgService } from './services/svg.service';
import { Svg } from './models/svg';
import { ChildNodeType } from './models/childNode-enum';

@Component({
  selector: 'svg-icon',
  standalone: true,
  imports: [],
  templateUrl: './svg-icon.component.html',
  styleUrl: './svg-icon.component.scss'
})
export class SvgIconComponent implements AfterViewInit {
  @ViewChild('myname', {static: false}) svgElement!: ElementRef
  @Input() iconName : string = ''
  @Input() className : string = ''
  
  svgLibrary = inject(SvgService)
  svg?: Svg

  ngAfterViewInit(): void {
    this.svgLibrary.loadIcons()
    this.svg = this.svgLibrary.getIcon(this.iconName)
    this.loadSvg()
  }

  loadSvg() {
    Object.entries(this.svg?.properties!)
    .forEach(([key, value]) => {
      this.setAttributes(this.svgElement!.nativeElement, key, value)
    })

    if (this.svg?.childNodes != null && this.svg?.childNodes?.length > 0) {
      this.svg.childNodes.forEach((child: any) => {
        this.setChildNode(this.svgElement!.nativeElement, child)
      })
    }

    this.setClass()
  }

  setAttributes(nativeElement: any, key: any, value: any){
    if(value == null) return
    nativeElement?.setAttributeNS('', key, value)
  }

  setChildNode(nativeElement: any, child: any){
    if (child == null) return

    switch(child.type){
      case ChildNodeType.Path:
        return this.appendPathElement(nativeElement, child)
      default:
        return
    }
  }

  appendPathElement(nativeElement: any, child: any) {
    const path = this.createPathElement()
    Object.entries(child).forEach(([key, value]) => {
      if (key !== 'type')
        this.setAttributes(path, key, value)
    })

    nativeElement.appendChild(path)
  }

  createPathElement(){
    return document.createElementNS('http://www.w3.org/2000/svg',"path")
  }

  setClass() {
    if (this.className == null) return
    this.svgElement?.nativeElement.setAttributeNS('', 'class', this.className!)
  }

}
